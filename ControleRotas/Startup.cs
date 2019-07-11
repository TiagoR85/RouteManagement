using ControleRotas.Context;
using ControleRotas.Middleware;
using ControleRotas.Models;
using ControleRotas.Repository;
using ControleRotas.Repository.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControleRotas
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSession();
            //Dependency Injection Context
            services.AddDbContext<RouteContext>(options => options.UseSqlServer(Configuration.GetConnectionString("RouteContext")));
            //services.AddDbContext<RouteContext>();

            //Dependency Injection Repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IAgendaRepository, AgendaRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IMunicipioRepository, MunicipioRepository>();
            services.AddScoped<IOrdemServicoRepository, OrdemServicoRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();

            //Validator Inject
            services.AddTransient<IValidator<Funcionario>, FuncionarioValidator>();
            services.AddTransient<IValidator<Agenda>, AgendaValidator>();
            services.AddTransient<IValidator<Email>, EmailValidator>();
            services.AddTransient<IValidator<Endereco>, EnderecoValidator>();
            services.AddTransient<IValidator<Municipio>, MunicipioValidator>();
            services.AddTransient<IValidator<OrdemServico>, OrdemServicoValidator>();
            services.AddTransient<IValidator<Pessoa>, PessoaValidator>();
            services.AddTransient<IValidator<Telefone>, TelefoneValidator>();
            services.AddTransient<IValidator<Veiculo>, VeiculoValidator>();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => 
                {
                    fv.ImplicitlyValidateChildProperties = true;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseSession();
            app.UseAuthentication();
            app.UseAuthenticationMiddleware();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}

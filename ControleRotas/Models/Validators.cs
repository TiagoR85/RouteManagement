using FluentValidation;

namespace ControleRotas.Models
{
    public class FuncionarioValidator : AbstractValidator<Funcionario>
    {
        public FuncionarioValidator()
        {
            RuleFor(f => f.UserName).NotNull().NotEmpty();
            RuleFor(f => f.Senha).NotNull().NotEmpty();
        }
    }

    public class AgendaValidator : AbstractValidator<Agenda>
    {
        public AgendaValidator()
        {
            RuleFor(a => a.NomeCompromisso).NotNull().NotEmpty().MinimumLength(10);
            RuleFor(f => f.Compromisso).NotNull().NotEmpty().MaximumLength(500);
            RuleFor(f => f.Valor).NotNull().NotEmpty().ScalePrecision(2,3);
        }
    }
    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(f => f.EndEmail).EmailAddress();
        }
    }
    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(f => f.Bairro).NotNull().NotEmpty().Length(5, 50);
            RuleFor(f => f.Logradouro).NotNull().NotEmpty().Length(5, 100);
            RuleFor(f => f.Cep).NotNull().NotEmpty().MaximumLength(8);
            RuleFor(f => f.Municipio).NotNull().NotEmpty();
        }
    }
    public class MunicipioValidator : AbstractValidator<Municipio>
    {
        public MunicipioValidator()
        {
            RuleFor(f => f.CodIbge).NotNull().NotEmpty();
            RuleFor(f => f.Nome).NotNull().NotEmpty().Length(3, 100);
        }
    }
    public class OrdemServicoValidator : AbstractValidator<OrdemServico>
    {
        public OrdemServicoValidator()
        {
            RuleFor(f => f.EndOrigem).NotNull().NotEmpty();
            RuleFor(f => f.EndDestino).NotNull().NotEmpty();
            RuleFor(f => f.KmPercorrida).NotNull().NotEmpty();
        }
    }
    public class PessoaValidator : AbstractValidator<Pessoa>
    {
        public PessoaValidator()
        {
            RuleFor(f => f.Cpf_Cnpj).NotNull().NotEmpty();
            RuleFor(f => f.NomeComp).NotNull().NotEmpty();
            RuleFor(f => f.TipoPessoa).IsInEnum();
        }
    }
    public class TelefoneValidator : AbstractValidator<Telefone>
    {
        public TelefoneValidator()
        {
            RuleFor(f => f.DDD).NotNull().NotEmpty();
            RuleFor(f => f.NumTelefone).NotNull().NotEmpty();
            RuleFor(f => f.TipoTelefone).IsInEnum();
        }
    }
    public class VeiculoValidator : AbstractValidator<Veiculo>
    {
        public VeiculoValidator()
        {
            RuleFor(f => f.Marca).NotNull().NotEmpty().IsInEnum();
            RuleFor(f => f.Disponivel).NotNull().NotEmpty().IsInEnum();
        }
    }
}

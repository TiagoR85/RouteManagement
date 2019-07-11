using ControleRotas.Context;
using ControleRotas.Models;
using ControleRotas.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ControleRotas.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(RouteContext context) : base(context) { }

        public override Funcionario GetById(int id)
        {
            return Context.Funcionarios
                .Include(p => p.Pessoa).ThenInclude(t => t.Telefones)
                .Include(p => p.Pessoa).ThenInclude(a => a.Agendas)
                .Include(p => p.Pessoa).ThenInclude(e => e.Emails)
                .Include(p => p.Pessoa).ThenInclude(end => end.Enderecos)
                .Where(f => f.FuncionarioId == id).First();
            //return Context.Funcionarios.Include(p => p.Pessoa).Where(f => f.FuncionarioId == id).First();
        }
    }
}

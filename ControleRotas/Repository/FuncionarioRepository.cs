using ControleRotas.Context;
using ControleRotas.Models;
using ControleRotas.Repository.Interfaces;
using System;
using System.Linq.Expressions;

namespace ControleRotas.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        private readonly IRepository<Funcionario> repository;
        public FuncionarioRepository(RouteContext context) : base(context) { }

        public override void SetActive(int id, bool active)
        {
            var entity = repository.GetById(id);
            entity.DataExclusao = active ? null : (DateTime?)DateTime.Now;
            repository.Save();
        }
    }
}

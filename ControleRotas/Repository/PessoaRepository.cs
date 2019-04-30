using ControleRotas.Context;
using ControleRotas.Models;
using ControleRotas.Repository.Interfaces;
using System;

namespace ControleRotas.Repository
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        private readonly IRepository<Pessoa> repository;
        public PessoaRepository(RouteContext context) : base(context) { }

        public override void SetActive(int id, bool active)
        {
            var entity = repository.GetById(id);
            entity.DataExclusao = active ? null : (DateTime?)DateTime.Now;
            repository.Save();
        }
    }
}

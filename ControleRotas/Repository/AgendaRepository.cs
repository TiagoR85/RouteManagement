using ControleRotas.Context;
using ControleRotas.Models;
using ControleRotas.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleRotas.Repository
{
    public class AgendaRepository : Repository<Agenda>, IAgendaRepository
    {
        private readonly IRepository<Agenda> repository;
        public AgendaRepository(RouteContext context) : base(context) { }

        public override ICollection<Agenda> GetAll()
        {
            return Context.Agendas.Where(p => p.Status == true).ToList();
        }
        public override void SetActive(int id, bool active)
        {
            var entity = repository.GetById(id);
            entity.DataInativacao = active ? null : (DateTime?)DateTime.Now;
            repository.Save();
        }
    }
}

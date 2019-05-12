using ControleRotas.Context;
using ControleRotas.Models;
using ControleRotas.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ControleRotas.Repository
{
    public class TelefoneRepository : Repository<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(RouteContext context) : base(context) { }

        public ICollection<Telefone> GetPhoneByPeople(Pessoa pessoa)
        {
            return Context.Telefones.Where(p => p.Pessoa == pessoa).ToList();
        }
    }
}

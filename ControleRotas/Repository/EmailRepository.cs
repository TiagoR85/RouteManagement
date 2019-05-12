using ControleRotas.Context;
using ControleRotas.Models;
using ControleRotas.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ControleRotas.Repository
{
    public class EmailRepository : Repository<Email>, IEmailRepository
    {
        public EmailRepository(RouteContext context) : base(context) { }

        public ICollection<Email> GetEmailByPeople(Pessoa pessoa)
        {
            return Context.Emails.Where(p => p.Pessoa == pessoa).ToList();
        }
    }
}

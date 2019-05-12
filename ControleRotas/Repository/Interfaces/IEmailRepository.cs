using ControleRotas.Models;
using System.Collections.Generic;

namespace ControleRotas.Repository.Interfaces
{
    public interface IEmailRepository : IRepository<Email>
    {
        ICollection<Email> GetEmailByPeople(Pessoa pessoa);
    }
}

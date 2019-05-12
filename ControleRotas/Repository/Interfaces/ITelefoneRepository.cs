using ControleRotas.Models;
using System.Collections.Generic;

namespace ControleRotas.Repository.Interfaces
{
    public interface ITelefoneRepository : IRepository<Telefone>
    {
        ICollection<Telefone> GetPhoneByPeople(Pessoa pessoa);
    }
}

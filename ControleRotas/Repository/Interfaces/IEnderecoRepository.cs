using ControleRotas.Models;
using System.Collections.Generic;

namespace ControleRotas.Repository.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        ICollection<Endereco> GetAdressByPeople(Pessoa pessoa);
    }
}

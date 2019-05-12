using ControleRotas.Context;
using ControleRotas.Models;
using ControleRotas.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ControleRotas.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(RouteContext context) : base(context) { }

        public ICollection<Endereco> GetAdressByPeople(Pessoa pessoa)
        {
            return Context.Enderecos.Include(m => m.Municipio).Where(p => p.Pessoa == pessoa).ToList();
        }
    }
}

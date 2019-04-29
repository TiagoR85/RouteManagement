using ControleRotas.Context;
using ControleRotas.Models;
using ControleRotas.Repository.Interfaces;

namespace ControleRotas.Repository
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(RouteContext context) : base(context)
        {
        }
    }
}

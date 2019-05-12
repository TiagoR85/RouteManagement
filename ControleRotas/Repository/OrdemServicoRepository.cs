using ControleRotas.Context;
using ControleRotas.Models;
using ControleRotas.Repository.Interfaces;
using System;

namespace ControleRotas.Repository
{
    public class OrdemServicoRepository : Repository<OrdemServico>, IOrdemServicoRepository
    {
        private readonly IRepository<OrdemServico> repository;
        public OrdemServicoRepository(RouteContext context) : base(context) { }
    }
}

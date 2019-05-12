using ControleRotas.Context;
using ControleRotas.Models;
using ControleRotas.Repository.Interfaces;
using System;

namespace ControleRotas.Repository
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        private readonly IRepository<Veiculo> repository;
        public VeiculoRepository(RouteContext context) : base(context) { }
    }
}

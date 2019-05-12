using ControleRotas.Context;
using ControleRotas.Models;
using ControleRotas.Repository.Interfaces;
using System;

namespace ControleRotas.Repository
{
    public class MunicipioRepository : Repository<Municipio>, IMunicipioRepository
    {
        private readonly IRepository<Municipio> repository;
        public MunicipioRepository(RouteContext context) : base(context) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleRotas.Models
{
    public partial class Veiculos
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public bool Disponivel { get; set; }
        public DateTime Ano { get; set; }
    }
}

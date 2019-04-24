using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleRotas.Models
{
    public partial class Municipio
    {
        public int MunicipioId { get; set; }
        public int CodIbge { get; set; }
        public string Nome { get; set; }
        public EnumEstadosBr Uf { get; set; }
    }
}

using System.Collections.Generic;
using static ControleRotas.Models.Enums;

namespace ControleRotas.Models
{
    public partial class Municipio
    {
        public int MunicipioId { get; set; }
        public int CodIbge { get; set; }
        public string Nome { get; set; }
        public EnumEstadosBr Uf { get; set; }
        public string Pais { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleRotas.Models
{
    [Table("Cidades")]
    public partial class Cidades
    {
        public int CodIbge { get; set; }
        public string Uf { get; set; }
        public string Nome { get; set; }
        public string Pais { get; set; }
    }
}

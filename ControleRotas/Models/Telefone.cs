using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleRotas.Models
{
    [Table("Telefone")]
    public partial class Telefone
    {
        public int Id { get; set; }
        [Column("Telefone")]
        public string NumTelefone { get; set; }
        public int TipoTelefone { get; set; }
        public int PessoaId { get; set; }
    }
}

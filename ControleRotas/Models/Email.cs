using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleRotas.Models
{
    [Table("Email")]
    public partial class Email
    {
        public int Id { get; set; }
        public string EndEmail { get; set; }
        public int PessoaId { get; set; }
    }
}

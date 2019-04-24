using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleRotas.Models
{
    public partial class Email
    {
        public int EmailId { get; set; }
        public string EndEmail { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}

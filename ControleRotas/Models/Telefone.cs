using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleRotas.Models
{
    public partial class Telefone
    {
        public int TelefoneId { get; set; }
        public string NumTelefone { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
        public int PessoaId { get; set; }
		public virtual Pessoa Pessoa { get; set; }
    }
}

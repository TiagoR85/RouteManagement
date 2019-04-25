using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleRotas.Models
{
    public partial class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string Senha { get; set; }
        public string NivelAcesso { get; set; }
        public string Cargo { get; set; }
        public virtual Pessoa Pessoa { get; set; }
	}
}

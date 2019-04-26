using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleRotas.Models
{
    public partial class Motorista
    {
        public int MotoristaId { get; set; }
        public string CodMotorista { get; set; }
        public virtual Veiculo Veiculo { get; set; }
        public virtual Pessoa Pessoa { get; set; }
	}
}

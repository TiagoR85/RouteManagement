using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleRotas.Models
{
    public partial class Motorista
    {
        public int Id { get; set; }
        public string CodMotorista { get; set; }
        public string CodVeiculo { get; set; }
        public int CodPessoa { get; set; }

    }
}

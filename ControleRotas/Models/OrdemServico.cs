using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleRotas.Models
{
    [Table("ordemServico")]
    public partial class OrdemServico
    {
        public int Id { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime DataFinal { get; set; }
        public DateTime DataPagamento { get; set; }
        public string Solicitante { get; set; }
        public string Passageiro { get; set; }
        public int EndBase { get; set; }
        public int EndOrigem { get; set; }
        public int EndDestino { get; set; }
        public string KmPercorrida { get; set; }
        public decimal ValorPedagio { get; set; }
        public decimal ValorCobrado { get; set; }
        public decimal Acrescimo { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }
        public string NumOs { get; set; }
        public string Observacao { get; set; }
        public string NfeMotorista { get; set; }
        public bool statusPag { get; set; }
        public int Veiculo { get; set; }
        public int Motorista { get; set; }

    }
}

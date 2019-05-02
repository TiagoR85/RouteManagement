using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleRotas.Models
{
    public partial class Agenda
    {
		public Agenda(){
            DataInclusao = DateTime.Now;
			DataAlteracao = DataInclusao;
		}
        public int AgendaId { get; set; }
        public string NomeCompromisso { get; set; }
        public string Compromisso { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime? DataInativacao { get; set; }
        public decimal Valor { get; set; }
        public int? FKOrdemServicoId { get; set; }

        [NotMapped]
        public bool Status
        {
            get { return DataInativacao == null; }
        }
    }
}

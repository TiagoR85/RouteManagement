using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleRotas.Models
{
    public partial class Agenda
    {
		public Agenda(){
            DataInclusao = DateTime.Now;
			DataAlteracao = DataInclusao;
		}

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AgendaId { get; set; }
        public string NomeCompromisso { get; set; }
        public string Compromisso { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataInclusao { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataAlteracao { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataInativacao { get; set; }
        public decimal Valor { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual OrdemServico OrdemServico { get; set; }

        [NotMapped]
        public bool Status
        {
            get { return DataInativacao == null; }
        }
    }
}

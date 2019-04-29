using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static ControleRotas.Models.Enums;

namespace ControleRotas.Models
{
    public partial class Veiculo
    {
		public Veiculo(){
            DataInclusao = DateTime.Now;
			DataAlteracao = DataInclusao;
			Status = TipoSituacao.Ativo;
            Disponivel = EnumTipoSimNao.Sim;
		}
		
        public int VeiculoId { get; set; }
        public EnumMarcaVeiculo Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Ano { get; set; }
		public string Renavan { get; set; }
		public EnumTipoSimNao Disponivel { get; set; }
		public TipoSituacao Status { get; set; }
	
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataInclusao { get; private set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataAlteracao { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataExclusao { get; set; }
    }
}

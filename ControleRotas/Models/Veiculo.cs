using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleRotas.Models
{
    public partial class Veiculo
    {
		public Veiculo(){
			DataInclusao = DateTime.Now
			DataAlteracao = DataInclusao;
			Ativo = TipoSituacao.Ativo;
		}
		
        public int VeiculoId { get; set; }
        public EnumMarcaVeiculo Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Ano { get; set; }
		public string Renavan { get; set; }
		public EnumTipoSimNao Disponivel { get; set; }
		public TipoSituacao Ativo { get; set; }
	
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataInclusao { get; private set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataAlteracao { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataExclusao { get; set; }
    }
}

using System;
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
        public DateTime DataInclusao { get; private set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}

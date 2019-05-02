using System;
using System.ComponentModel.DataAnnotations.Schema;
using static ControleRotas.Models.Enums;

namespace ControleRotas.Models
{
    public partial class OrdemServico
    {
		public OrdemServico()
		{
			DataInclusao = DateTime.Now;
			DataAlteracao = DataInclusao;
			Ativo = TipoSituacao.Ativo;
			SituacaoServico = TipoSituacaoConta.Aberto;
            Urgencia = TipoUrgencia.Media;
            DataInclusao = DataInclusao;
            DataAlteracao = DataAlteracao;
		}
		
        public int OrdemServicoId { get; set; }
        public TipoSituacao Ativo { get; set; }
        public TipoUrgencia Urgencia { get; set; }
        public DateTime DataInclusao { get; private set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int? FkPessoaIdSolicitante { get; set; }
        public string Passageiro { get; set; }
        public string EndBase { get; set; }
        public string EndOrigem { get; set; }
        public string EndDestino { get; set; }
        public string KmPercorrida { get; set; }
        public decimal? ValorPedagio { get; set; }
        public decimal? ValorCobrado { get; set; }
        public decimal? Acrescimo { get; set; }
        public decimal? Desconto { get; set; }
        public decimal? ValorTotal { get; set; }
        public string NumOs { get; set; }
        public string Observacao { get; set; }
        public string NfSeMotorista { get; set; }
        public TipoSituacaoConta SituacaoServico { get; set; }
        public int? FkVeiculo { get; set; }
        public int? FkAgenda { get; set; }

        [NotMapped]
        public bool Status => DataExclusao == null;

    }
}

﻿using System;
using System.ComponentModel.DataAnnotations;
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
		}
		
        public int OrdemServicoId { get; set; }
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
		
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataPagamento { get; set; }
		
        public virtual Pessoa Solicitante { get; set; }
        public string Passageiro { get; set; }
        public virtual Endereco EndBase { get; set; }
        public virtual Endereco EndOrigem { get; set; }
        public virtual Endereco EndDestino { get; set; }
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
        public virtual Veiculo Veiculo { get; set; }
        public virtual Motorista Motorista { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static ControleRotas.Models.Enums;

namespace ControleRotas.Models
{
    public partial class Pessoa
    {
		public Pessoa(){
            DataInclusao = DateTime.Now;
			DataAlteracao = DataInclusao;
            Status = TipoSituacao.Ativo;
            Emails = new List<Email>();
            Telefones = new List<Telefone>();
            Enderecos = new List<Endereco>();
            Agendas = new List<Agenda>();

        }
        public int PessoaId { get; set; }

        public string NomeComp { get; set; }

        public string RazaoSocial { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataInclusao { get; private set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataAlteracao { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? DataExclusao { get; set; }

        public TipoContrante TipoContrante { get; set; }

        public TipoSituacao Status { get; set; }

        [Required]
        public TipoPessoa TipoPessoa { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Nascimento { get; set; }

        [MaxLength(14, ErrorMessage = "Favor inserir apenas números"), MinLength(11)]
        public string Cpf_Cnpj { get; set; }

        [MaxLength(20, ErrorMessage = "Favor inserir apenas números"), MinLength(9)]
        public string Ie_Rg { get; set; }

        public string InscrMunicipal { get; set; }

        public string Grupo { get; set; }

        public virtual Funcionario Funcionario { get; set; }

        public virtual IList<Email> Emails { get; set; }

        public virtual IList<Endereco> Enderecos { get; set; }

        public virtual IList<Telefone> Telefones { get; set; }

        public virtual IList<Agenda> Agendas { get; set; }
    }
}

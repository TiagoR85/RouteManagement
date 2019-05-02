using System;
using System.Collections.Generic;
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
        public DateTime DataInclusao { get; private set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public TipoContrante TipoCadastro { get; set; }
        public TipoSituacao Status { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public DateTime? Nascimento { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string Ie_Rg { get; set; }
        public string InscrMunicipal { get; set; }
        public string Grupo { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
        public virtual ICollection<Agenda> Agendas { get; set; }
    }
}

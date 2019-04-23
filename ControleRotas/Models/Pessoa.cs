using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleRotas.Models
{
    public partial class Pessoa
    {
		private string _razaoSocial;
		
		public Pessoa(){
			DataInclusao = new DateTime().Now;
			DataAlteracao = DataInclusao;
			Ativo = true;
		}
		
        public int PessoaId { get; set; }
		public string NomeComp { get; set; }
		public string RazaoSocial { get; set => _razaoSocial == null ? NomeComp : _razaoSocial }
        public DateTime DataInclusao { get; private set; }
		[Required]
        public DateTime DataAlteracao { get; set; }
        public DateTime DataExclusao { get; set; }
		public TipoContrante TipoContrante { get; set; }
        public EnumStatusPeoples Ativo { get; set; }
		[Required]
        public TipoPessoa TipoPessoa { get; set; }
        public DateTime Nascimento { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string Ie_Rg { get; set; }

        public ICollection<Email> Emails { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
    }
}

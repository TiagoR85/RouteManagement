using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleRotas.Models
{
    [Table("Pessoas")]
    public partial class Pessoas
    {
        public int Id { get; set; }
        public string NomeComp { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime DataExclusao { get; set; }
        public bool Ativo { get; set; }
        public int TipoPessoa { get; set; }
        public DateTime Nascimento { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string Ie_Rg { get; set; }

        [NotMapped]
        public ICollection<Email> Emails { get; set; }
        [NotMapped]
        public ICollection<Endereco> Enderecos { get; set; }
        [NotMapped]
        public ICollection<Telefone> Telefones { get; set; }
    }
}

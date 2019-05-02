using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleRotas.Models
{
    public partial class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string NivelAcesso { get; set; }
        public string Cargo { get; set; }
        public bool TrocarSenha { get; set; }
        public string UserName { get; set; }
        public string Senha { get; set; }
        public DateTime? DataExclusao { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        [NotMapped]
        public string ConfirmaSenha { get; set; }
        [NotMapped]
        public bool IsSupportMode { get; set; }
        [NotMapped]
        public bool IsSuperUser { get; set; }
    }
}

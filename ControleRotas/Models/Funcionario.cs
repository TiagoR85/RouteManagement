using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleRotas.Models
{
    public partial class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string NivelAcesso { get; set; }
        public string Cargo { get; set; }

        [Display(Name = "Trocar Senha")]
        public bool TrocarSenha { get; set; }
        

        [Required(ErrorMessage = "Usuário/Senha inválido")]
        [MaxLength(100)]
        [Display(Name="E-mail")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Usuário/Senha inválido")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
        [MinLength(6, ErrorMessage = "Mínimo 6 caracteres")]
        public string Senha { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        [NotMapped]
        [Display(Name = "Confirma Senha")]
        public string ConfirmaSenha { get; set; }
        [NotMapped]
        public bool IsSupportMode { get; set; }
        [NotMapped]
        public bool IsSuperUser { get; set; }
    }
}

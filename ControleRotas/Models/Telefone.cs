using static ControleRotas.Models.Enums;

namespace ControleRotas.Models
{
    public partial class Telefone
    {
        public int TelefoneId { get; set; }
        public string NumTelefone { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
		public virtual Pessoa Pessoa { get; set; }
    }
}

using static ControleRotas.Models.Enums;

namespace ControleRotas.Models
{
    public partial class Municipio
    {
        public int EnderecoId { get; set; }
        public int CodIbge { get; set; }
        public string Nome { get; set; }
        public EnumEstadosBr Uf { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}

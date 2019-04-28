namespace ControleRotas.Models
{
    public partial class Endereco
    {
        public int EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public virtual Municipio Municipio { get; set; }
		public virtual Pessoa Pessoa { get; set; }
    }
}

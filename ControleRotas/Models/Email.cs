namespace ControleRotas.Models
{
    public partial class Email
    {
        public int EmailId { get; set; }
        public string EndEmail { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}

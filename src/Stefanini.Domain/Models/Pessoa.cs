namespace Stefanini.Domain.Models
{
    public class Pessoa : Entity
    {      
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int Idade { get; set; }
        public int Id_Cidade { get; set; }
        public Cidade Cidade { get; set; }
    }
}

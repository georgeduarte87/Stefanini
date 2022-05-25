namespace Stefanini.Domain.Models
{
    public class Cidade : Entity
    {
        public string Nome { get; set; }

        public string UF { get; set; }

        public IEnumerable<Pessoa> Pessoas { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Stefanini.API.ViewModels
{
    public class CidadeViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(8, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 8)]
        public string UF { get; set; }

        public IEnumerable<PessoaViewModel> Pessoas { get; set; }
    }
}

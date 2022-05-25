using System.ComponentModel.DataAnnotations;

namespace Stefanini.API.ViewModels
{
    public class PessoaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 11)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Idade { get; set; }

        [ScaffoldColumn(false)]
        public string NomeCidade { get; set; }

        [ScaffoldColumn(false)]
        public string NomeUF { get; set; }
    }
}

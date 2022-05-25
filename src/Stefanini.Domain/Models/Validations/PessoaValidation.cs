using FluentValidation;
using Stefanini.Domain.Models.Validations.Documentos;

namespace Stefanini.Domain.Models.Validations
{
    public  class PessoaValidation : AbstractValidator<Pessoa>
    {
        public PessoaValidation()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(p => p.CPF.Length).Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

            RuleFor(p => CpfValidacao.Validar(p.CPF)).Equal(true)
                .WithMessage("O documento fornecido é inválido.");

            RuleFor(p => p.Idade)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

        }
    }
}

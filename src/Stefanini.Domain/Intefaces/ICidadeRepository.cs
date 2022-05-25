using Stefanini.Domain.Models;

namespace Stefanini.Domain.Intefaces
{
    public interface ICidadeRepository : IRepository<Cidade>
    {
        Task<Cidade> ObterPessoasDaCidade(int id);
    }
}

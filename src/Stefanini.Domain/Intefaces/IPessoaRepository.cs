using Stefanini.Domain.Models;

namespace Stefanini.Domain.Intefaces
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        Task<IEnumerable<Pessoa>> ObterCidadePessoas();

        Task<Pessoa> ObterCidadePessoa(int id);
    }
}

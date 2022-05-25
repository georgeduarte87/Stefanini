using Stefanini.Domain.Models;

namespace Stefanini.Domain.Intefaces
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        Task<Pessoa> ObterCidadeDaPessoa(int id);
    }
}

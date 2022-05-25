using Stefanini.Domain.Models;

namespace Stefanini.Domain.Intefaces
{
    public interface ICidadeService : IDisposable
    {
        Task<bool> Adicional(Cidade cidade);
        Task<bool> Atualizar(Cidade cidade);
        Task<bool> Remover(int id);
    }
}

using Stefanini.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Domain.Intefaces
{
    public interface IPessoaService : IDisposable
    {
        Task<bool> Adicionar(Pessoa pessoa);
        Task<bool> Atualizar(Pessoa pessoa);
        Task<bool> Remover(int id);
    }
}

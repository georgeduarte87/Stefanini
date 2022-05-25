using Stefanini.Data.Context;
using Stefanini.Domain.Models;
using Stefanini.Domain.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace Stefanini.Data.Repository
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(StefaniniDbContext context) : base(context) { }

        public async Task<IEnumerable<Pessoa>> ObterCidadePessoas()
        {
            return await Db.Pessoas.AsNoTracking().Include(c => c.Cidade).OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<Pessoa> ObterCidadePessoa(int id)
        {
            return await Db.Pessoas.AsNoTracking().Include(c => c.Cidade).FirstOrDefaultAsync(p => p.Id == id);
        }   
    }
}

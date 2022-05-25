using Microsoft.EntityFrameworkCore;
using Stefanini.Data.Context;
using Stefanini.Domain.Intefaces;
using Stefanini.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Data.Repository
{
    public class CidadeRepository : Repository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(StefaniniDbContext context) : base(context) { }

        public async Task<Cidade> ObterPessoasPorCidade(int id)
        {
            return await Db.Cidades.AsNoTracking()
                .Include(c => c.Pessoas)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}

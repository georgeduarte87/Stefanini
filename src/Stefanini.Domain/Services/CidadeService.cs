using Stefanini.Domain.Intefaces;
using Stefanini.Domain.Models;
using Stefanini.Domain.Models.Validations;

namespace Stefanini.Domain.Services
{
    public class CidadeService : BaseService, ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeService(ICidadeRepository cidadeRepository,
                             INotificador notificador) : base(notificador)
        {
            _cidadeRepository = cidadeRepository;
        }

        public async Task<bool> Adicionar(Cidade cidade)
        {
            if (!ExecutarValidacao(new CidadeValidation(), cidade)) return false;

            if (_cidadeRepository.Buscar(c => c.Nome == cidade.Nome).Result.Any())
            {
                Notificar("Já existe uma cidade com este nome informado.");
                return false;
            }

            await _cidadeRepository.Adicionar(cidade);
            return true;
        }

        public async Task<bool> Atualizar(Cidade cidade)
        {
            if (!ExecutarValidacao(new CidadeValidation(), cidade)) return false;

            if (_cidadeRepository.Buscar(c => c.Nome == cidade.Nome && c.Id != cidade.Id).Result.Any())
            {
                Notificar("Já existe uma cidade com este nome informado.");
                return false;
            }

            await _cidadeRepository.Atualizar(cidade);
            return true;
        }

        public async Task<bool> Remover(int id)
        {
            if (_cidadeRepository.ObterPessoasDaCidade(id).Result.Pessoas.Any())
            {
                Notificar("A cidade possui pessoas cadastradas!");
                return false;
            }

            await _cidadeRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _cidadeRepository?.Dispose();
        }
    }
}

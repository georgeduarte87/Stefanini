using Stefanini.Domain.Intefaces;
using Stefanini.Domain.Models;
using Stefanini.Domain.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Domain.Services
{
    public class PessoaService : BaseService, IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository,
                             INotificador notificador) : base(notificador)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<bool> Adicionar(Pessoa pessoa)
        {
            if (!ExecutarValidacao(new PessoaValidation(), pessoa)) return false;

            if (_pessoaRepository.Buscar(p => p.CPF == pessoa.CPF).Result.Any())
            {
                Notificar("Já existe uma pessoa com este documento informado.");
                return false;
            }

            await _pessoaRepository.Adicionar(pessoa);
            return true;
        }

        public async Task<bool> Atualizar(Pessoa pessoa)
        {
            if (!ExecutarValidacao(new PessoaValidation(), pessoa)) return false;

            if (_pessoaRepository.Buscar(p => p.CPF == pessoa.CPF && p.Id != pessoa.Id).Result.Any())
            {
                Notificar("Já existe uma com este CPF informado.");
                return false;
            }

            await _pessoaRepository.Atualizar(pessoa);
            return true;
        }

        public async Task<bool> Remover(int id)
        {
            await _pessoaRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _pessoaRepository?.Dispose();
        }
    }
}

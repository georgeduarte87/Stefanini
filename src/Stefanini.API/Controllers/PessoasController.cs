using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stefanini.API.ViewModels;
using Stefanini.Domain.Intefaces;
using Stefanini.Domain.Models;

namespace Stefanini.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : MainController
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;

        public PessoasController(INotificador notificador,
                                 IPessoaRepository pessoaRepository,
                                 IPessoaService pessoaService,
                                 IMapper mapper) : base(notificador)
        {
            _pessoaRepository = pessoaRepository;
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PessoaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<PessoaViewModel>>(await _pessoaRepository.ObterCidadePessoas());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PessoaViewModel>> ObterPorId(int id)
        {
            var produtoViewModel = await ObterPessoa(id);

            if (produtoViewModel == null) return NotFound();

            return produtoViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<PessoaViewModel>> Adicionar(PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pessoaService.Adicionar(_mapper.Map<Pessoa>(pessoaViewModel));

            return CustomResponse(pessoaViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar(int id, PessoaViewModel pessoaViewModel)
        {
            if (id != pessoaViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(pessoaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pessoaService.Atualizar(_mapper.Map<Pessoa>(pessoaViewModel));

            return CustomResponse(pessoaViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PessoaViewModel>> Excluir(int id)
        {
            var pessoaViewModel = await ObterPessoa(id);

            if (pessoaViewModel == null) return NotFound();

            await _pessoaService.Remover(id);

            return CustomResponse(pessoaViewModel);
        }

        private async Task<PessoaViewModel> ObterPessoa(int id)
        {
            return _mapper.Map<PessoaViewModel>(await _pessoaRepository.ObterCidadePessoa(id));
        }
    }
}

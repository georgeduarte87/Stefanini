using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Stefanini.API.ViewModels;
using Stefanini.Domain.Intefaces;
using Stefanini.Domain.Models;

namespace Stefanini.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadesController : MainController
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly ICidadeService _cidadeService;
        private readonly IMapper _mapper;

        public CidadesController(INotificador notificador,
                                  ICidadeRepository cidadeRepository,
                                  ICidadeService cidadeService,
                                  IMapper mapper) : base(notificador)
        {
            _cidadeRepository = cidadeRepository;
            _cidadeService = cidadeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CidadeViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CidadeViewModel>>(await _cidadeRepository.ObterTodos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CidadeViewModel>> ObterPorId(int id)
        {
            var cidadeViewModel = await ObterCidade(id);

            if (cidadeViewModel == null) return NotFound();

            return cidadeViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<CidadeViewModel>> Adicionar(CidadeViewModel cidadeViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _cidadeService.Adicionar(_mapper.Map<Cidade>(cidadeViewModel));

            return CustomResponse(cidadeViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar(int id, CidadeViewModel cidadeViewModel)
        {
            if (id != cidadeViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(cidadeViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _cidadeService.Atualizar(_mapper.Map<Cidade>(cidadeViewModel));

            return CustomResponse(cidadeViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CidadeViewModel>> Excluir(int id)
        {
            var cidadeViewModel = await ObterPessoasDaCidade(id);

            if (cidadeViewModel == null) return NotFound();

            await _cidadeService.Remover(id);

            return CustomResponse(cidadeViewModel);
        }

        private async Task<CidadeViewModel> ObterCidade(int id)
        {
            return _mapper.Map<CidadeViewModel>(await _cidadeRepository.ObterPorId(id));
        }

        private async Task<CidadeViewModel> ObterPessoasDaCidade(int id)
        {
            return _mapper.Map<CidadeViewModel>(await _cidadeRepository.ObterPessoasDaCidade(id));
        }
        
    }
}

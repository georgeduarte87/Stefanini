using AutoMapper;
using Stefanini.API.ViewModels;
using Stefanini.Domain.Models;

namespace Stefanini.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Cidade, CidadeViewModel>().ReverseMap();
            CreateMap<PessoaViewModel, Pessoa>();
            CreateMap<Pessoa, PessoaViewModel>()
                .ForMember(dest => dest.NomeCidade, opt => opt.MapFrom(src => src.Cidade.Nome))
                .ForMember(dest => dest.NomeUF, opt => opt.MapFrom(src => src.Cidade.UF));
        }
    }
}

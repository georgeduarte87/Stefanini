using Stefanini.Data.Context;
using Stefanini.Data.Repository;
using Stefanini.Domain.Intefaces;
using Stefanini.Domain.Notificacoes;
using Stefanini.Domain.Services;

namespace Stefanini.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<StefaniniDbContext>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<ICidadeService, CidadeService>();
            services.AddScoped<IPessoaService, PessoaService>();

            return services;
        }
    }
}

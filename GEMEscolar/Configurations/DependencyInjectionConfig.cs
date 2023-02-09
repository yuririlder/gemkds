using GEMEscolar.Core.Interface;
using GEMEscolar.Core.Repository;
using GEMEscolar.Infra.Interface;
using GEMEscolar.Infra.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GEMEscolar.Configurations
{
    public static class DependencyInjectionConfig
    {
        internal static void RegisterServicesConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //services
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAlunosService, AlunosService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IResponsavelService, ResponsavelService>();
            services.AddScoped<IInadiplentesService, InadiplentesService>();
            services.AddScoped<IMensalidadesService, MensalidadesService>();
            services.AddScoped<ITurmasService, TurmasService>();
            services.AddScoped<IProfessoresService, ProfessoresService>();
            services.AddScoped<IPagamentoService, PagamentoService>();

            //repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IResponsavelRepository, ResponsavelRepository>();
            services.AddScoped<IAlunosRepository, AlunosRepository>();
            services.AddScoped<IMensalidadesRepository, MensalidadesRepository>();
            services.AddScoped<ITurmasRepository, TurmasRepository>();
            services.AddScoped<IProfessoresRepository, ProfessoresRepository>();

            //service HTTP
        }
    }
}

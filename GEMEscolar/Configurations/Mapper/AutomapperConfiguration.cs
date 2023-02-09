using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GEMEscolar.Configurations.Mapper
{
    public static class AutomapperConfiguration
    {
        public static void ConfigureAutomapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingUser());
                mc.AddProfile(new MappingAlunos());
                mc.AddProfile(new MappingResponsavel());
            });

            IMapper mapper = new AutoMapper.Mapper(mappingConfig);
            services.TryAddSingleton(mapper);
        }
    }
}

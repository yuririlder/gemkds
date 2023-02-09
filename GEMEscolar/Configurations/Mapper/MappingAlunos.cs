using AutoMapper;
using GEMEscolar.Core.Entities;
using GEMEscolar.Core.Models;

namespace GEMEscolar.Configurations.Mapper
{
    public class MappingAlunos : Profile
    {
        public MappingAlunos()
        {
            CreateMap<Alunos, CriarAlunoResponsavelModelo>()
                .ForMember(dest => dest.IdAluno, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        }

    }
}

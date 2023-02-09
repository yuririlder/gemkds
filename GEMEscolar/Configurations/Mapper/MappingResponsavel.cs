using AutoMapper;
using GEMEscolar.Core.Entities;
using GEMEscolar.Core.Models;

namespace GEMEscolar.Configurations.Mapper
{
    public class MappingResponsavel : Profile
    {
        public MappingResponsavel()
        {
            CreateMap<Responsavel, CriarAlunoResponsavelModelo>()
                .ForMember(dest => dest.IdResponsavel, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NomeResponsavel, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.TelefoneResponsavel, opt => opt.MapFrom(src => src.Telefone))
                .ForMember(dest => dest.TelefoneResponsavel2, opt => opt.MapFrom(src => src.Telefone2))
                .ForMember(dest => dest.EstadoResponsavel, opt => opt.MapFrom(src => src.Estado))
                .ForMember(dest => dest.EnderecoResponsavel, opt => opt.MapFrom(src => src.Endereco))
                .ForMember(dest => dest.CidadeResponsavel, opt => opt.MapFrom(src => src.Cidade))
                .ForMember(dest => dest.Rg, opt => opt.MapFrom(src => src.Rg))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
                .ReverseMap();
        }

    }
}

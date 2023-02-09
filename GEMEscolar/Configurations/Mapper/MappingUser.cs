using AutoMapper;
using GEMEscolar.Infra.Models;
using GEMEscolar.Core.Entities;

namespace GEMEscolar.Configurations.Mapper
{
    public class MappingUser : Profile
    {
        public MappingUser()
        {
            CreateMap<Users, UserModel>()
                .ReverseMap();
        }

    }
}

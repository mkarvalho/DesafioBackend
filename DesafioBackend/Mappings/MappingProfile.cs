using AutoMapper;
using DesafioBackend.DTO;
using DesafioBackend.Entities;

namespace DesafioBackend.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Profile, ProfileDTO>().ReverseMap();
        }
    }
}

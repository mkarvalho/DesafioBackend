
using DesafioBackend.DTO;

namespace DesafioBackend.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Profile, ProfileDTO>().ReverseMap();
            CreateMap<Entities.Profile, ProfileCreateDTO>().ReverseMap();
            CreateMap<Entities.Profile, ProfileUpdateDTO>().ReverseMap();
        }
    }
}

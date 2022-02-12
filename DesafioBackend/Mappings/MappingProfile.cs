
using DesafioBackend.DTO;
using DesafioBackend.DTO.User;

namespace DesafioBackend.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Profile, ProfileDTO>().ReverseMap();
            CreateMap<Entities.Profile, ProfileCreateDTO>().ReverseMap();
            CreateMap<Entities.Profile, ProfileUpdateDTO>().ReverseMap();

            CreateMap<Entities.User, UserCreateDTO>().ReverseMap();
            CreateMap<Entities.User, UserResultDTO>().ReverseMap();
            CreateMap<UserCreateDTO, UserResultDTO>().ReverseMap();
        }
    }
}

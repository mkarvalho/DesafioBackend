using AutoMapper;
using DesafioBackend.DTO;
using DesafioBackend.Repositories.Interfaces;
using DesafioBackend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioBackend.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;

        public ProfileService(IProfileRepository profileRepository, IMapper mapper)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
        }



        public async Task<IList<ProfileDTO>> GetAll()
        {
            var profiles = await _profileRepository.GetAll();
            var result = _mapper.Map<IList<ProfileDTO>>(profiles);
            return result;
        }

        public async Task<ProfileDTO> GetById(Guid id)
        {
            var profile = await _profileRepository.GetById(id);
            var result = _mapper.Map<ProfileDTO>(profile);
            return result;
        }

        public async Task<ProfileDTO> Create(ProfileCreateDTO profileCreateDTO)
        {
            var profile = _mapper.Map<Entities.Profile>(profileCreateDTO);
            var profileCreated = await _profileRepository.Create(profile);
            return _mapper.Map<ProfileDTO>(profileCreated);
        }

        public async Task Remove(Guid id)
        {
            await _profileRepository.Remove(id);
        }

        public Task<ProfileDTO> Update(ProfileDTO profile)
        {
            throw new NotImplementedException();
        }
    }
}


using DesafioBackend.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioBackend.Services.Interfaces
{
    public interface IProfileService
    {
        Task<IList<ProfileDTO>> GetAll();
        Task<ProfileDTO> GetById(Guid id);
        Task<ProfileDTO> Create(ProfileCreateDTO profileCreateDTO);
        Task<ProfileDTO> Update(ProfileDTO profileDTO);
        Task Remove(Guid id);
    }
}

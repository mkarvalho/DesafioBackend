using DesafioBackend.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioBackend.Repositories.Interfaces
{
    public interface IProfileRepository
    {
        Task<List<Profile>> GetAll();

        Task<Profile> GetById(Guid id);

        Task<Profile> Create(Profile profile);

        Task<Profile> Update(Profile profile);

        Task Remove(Guid id);
    }
}
using DesafioBackend.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioBackend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetById(Guid id);
        Task<User> Create(User user);

        Task CreateUserProfile(User user);

        Task<User> Update(User user);
        Task Remove(Guid id);
    }
}

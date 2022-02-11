using DesafioBackend.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioBackend.Services.Interfaces
{
    public interface IUserService
    {
        Task<IList<User>> GetAll();
        Task<User> GetById(Guid id);
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task Remove(Guid id);
    }
}

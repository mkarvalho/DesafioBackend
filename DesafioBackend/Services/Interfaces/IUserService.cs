using DesafioBackend.DTO.User;
using DesafioBackend.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioBackend.Services.Interfaces
{
    public interface IUserService
    {
        Task<IList<UserResultDTO>> GetAll();
        Task<User> GetById(Guid id);
        Task<UserResultDTO> Create(UserCreateDTO userCreateDTO);
        Task<User> Update(User user);
        Task Remove(Guid id);
    }
}

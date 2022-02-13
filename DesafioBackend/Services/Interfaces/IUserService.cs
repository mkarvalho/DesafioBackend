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
        Task<User> GetByEmail(string email);
        Task<UserResultDTO> Create(UserCreateDTO userCreateDTO);
        Task<UserResultDTO> Update(UserUpdateDTO userUpdateDTO);
        Task Remove(Guid id);
    }
}

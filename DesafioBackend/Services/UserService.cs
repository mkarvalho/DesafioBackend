using AutoMapper;
using DesafioBackend.Entities;
using DesafioBackend.Repositories.Interfaces;
using DesafioBackend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
 
        public async Task<IList<User>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return users;
        }

        public async Task<User> GetById(Guid id)
        { 
            return await _userRepository.GetById(id);
        }

        public async Task<User> Create(User user)
        {
            return await _userRepository.Create(user);
           
        }
        public async Task Remove(Guid id)
        {
            await _userRepository.Remove(id);
        }

        public async Task<User> Update(User user)
        {
            return await _userRepository.Update(user);
        }
    }
}

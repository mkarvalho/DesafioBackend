using AutoMapper;
using DesafioBackend.DTO.User;
using DesafioBackend.Entities;
using DesafioBackend.Repositories.Interfaces;
using DesafioBackend.Services.Interfaces;
using SecureIdentity.Password;
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

        public async Task<IList<UserResultDTO>> GetAll()
        {
            var users = await _userRepository.GetAll();
            var result = _mapper.Map<IList<UserResultDTO>>(users);
            return result;
        }

        public async Task<User> GetById(Guid id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _userRepository.GetByEmail(email);
        }

        public async Task<UserResultDTO> Create(UserCreateDTO userCreateDTO)
        {
            var user = _mapper.Map<User>(userCreateDTO);

            user.Password = PasswordHasher.Hash(user.Password);

            var userCreated = await _userRepository.Create(user);
            var result = _mapper.Map<UserResultDTO>(userCreated);
            return result;
        }

        public async Task Remove(Guid id)
        {
            await _userRepository.Remove(id);
        }

        public async Task<UserResultDTO> Update(UserUpdateDTO userUpdateDTO)
        {
            var user = _mapper.Map<User>(userUpdateDTO);

            user.Password = PasswordHasher.Hash(user.Password);

            var userUpdated = await _userRepository.Update(user);
            return _mapper.Map<UserResultDTO>(userUpdated);
        }
    }
}
using System;
using System.Collections.Generic;

namespace DesafioBackend.DTO.User
{
    public class UserUpdateDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IList<ProfileCreateDTO> Profiles { get; set; }
    }
}
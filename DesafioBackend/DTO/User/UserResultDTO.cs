using DesafioBackend.Entities;
using System;
using System.Collections.Generic;

namespace DesafioBackend.DTO.User
{
    public class UserResultDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime LastLogin { get; set; } 
        public IList<Profile> Profiles { get; set; }


    }
}

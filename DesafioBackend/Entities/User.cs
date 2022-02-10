using System;
using System.Collections.Generic;

namespace DesafioBackend.Entities
{
    public class User : Base
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public IList<Profile> Profiles { get; set; }
    }
}

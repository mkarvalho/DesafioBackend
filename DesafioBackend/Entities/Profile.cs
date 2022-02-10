using System;
using System.Collections.Generic;

namespace DesafioBackend.Entities
{
    public class Profile : Base
    {
        public string Name { get; set; }
        
        public IList<User> Users { get; set; }
    }
}

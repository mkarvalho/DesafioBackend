using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DesafioBackend.Entities
{
    public class Profile : Base
    {
        public string Name { get; set; }
        
        [JsonIgnore]
        public IList<User> Users { get; set; }
    }
}

using System;
using System.Text.Json.Serialization;

namespace DesafioBackend.DTO
{
    public class ProfileUpdateDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public DateTime Modified { get; set; }
    }
}
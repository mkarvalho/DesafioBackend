using System;

namespace DesafioBackend.DTO
{
    public class ProfileCreateDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
    }
}

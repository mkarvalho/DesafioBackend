using System;

namespace DesafioBackend.DTO
{
    public class ProfileDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
    }
}

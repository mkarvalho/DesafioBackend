using System;

namespace DesafioBackend.Entities
{
    public abstract class Base
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
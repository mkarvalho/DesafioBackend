using DesafioBackend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DesafioBackend.Data
{
    public class EFDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public EFDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Profile>()
                .HasData(
                new Profile
                { Name = "Admin" },
                new Profile
                { Name = "Caixa" },
                new Profile
                { Name = "Operador" }
            );

            modelBuilder.Entity<User>().Property(x => x.LastLogin).IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }

    }
}

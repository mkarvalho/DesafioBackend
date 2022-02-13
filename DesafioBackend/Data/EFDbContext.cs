using DesafioBackend.Entities;
using Microsoft.EntityFrameworkCore;
using System;

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
                { Name = "Admin", Created = DateTime.Now, Modified = DateTime.Now },
                new Profile
                { Name = "Caixa", Created = DateTime.Now, Modified = DateTime.Now },
                new Profile
                { Name = "Operador", Created = DateTime.Now, Modified = DateTime.Now }
            );

            modelBuilder.Entity<User>().Property(x => x.LastLogin).IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
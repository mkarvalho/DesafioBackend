using DesafioBackend.Data;
using DesafioBackend.Entities;
using DesafioBackend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioBackend.Repositories
{
    public class UserRepository : DapperDbContext, IUserRepository
    {
        private readonly EFDbContext _dbContext;

        public UserRepository(IConfiguration configuration, EFDbContext dbContext) : base(configuration)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetAll()
        {
            return await _dbContext.Users.Include(p => p.Profiles).AsNoTracking().ToListAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _dbContext.Users.Include(p => p.Profiles).AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<User> Create(User user)
        {
            user.Created = DateTime.Now;
            user.Modified = user.Created;
            user.LastLogin = user.Created;
            await CreateUserProfile(user);
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task CreateUserProfile(User user)
        {
            var profiles = new List<Profile>();
            foreach (var profile in user.Profiles)
            {
                var profileExists = await _dbContext.Profiles.FirstOrDefaultAsync(x => x.Name == profile.Name);
                profiles.Add(profileExists);
            }
            user.Profiles = profiles;
        }

        public async Task Remove(Guid id)
        {
            var user = await GetById(id);
            if (user != null)
            {
                _dbContext.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<User> Update(User user)
        {
            var userDB = await _dbContext.Users.Include(p => p.Profiles).SingleOrDefaultAsync(p => p.Id == user.Id);

            if (userDB == null)
            {
                return null;
            }

            user.Created = userDB.Created;
            user.Modified = DateTime.Now;
            user.LastLogin = userDB.LastLogin;

            _dbContext.Entry(userDB).CurrentValues.SetValues(user);

            await UpdateUserProfile(user, userDB);

            await _dbContext.SaveChangesAsync();
            return userDB;
        }

        private async Task UpdateUserProfile(User user, User userConsulted)
        {
            userConsulted.Profiles.Clear();
            foreach (var profile in user.Profiles)
            {
                var profileExists = await _dbContext.Profiles.FirstOrDefaultAsync(x => x.Name == profile.Name);
                profileExists.Modified = profileExists.Modified;
                profileExists.Created = profileExists.Created;
                userConsulted.Profiles.Add(profileExists);
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            var userEmail = await _dbContext.Users.Include(p => p.Profiles).SingleOrDefaultAsync(e => e.Email == email);
            return userEmail;
        }
    }
}
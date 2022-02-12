using Dapper;
using DesafioBackend.Data;
using DesafioBackend.Entities;
using DesafioBackend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            using IDbConnection conn = DapperConnection;
            conn.Open();
            var sql = "SELECT * FROM \"Users\"";
            var result = await conn.QueryAsync<User>(sql);
            return result.OrderBy(x => x.Name).ToList();
        }

        public async Task<User> GetById(Guid id)
        {
            using IDbConnection conn = DapperConnection;
            conn.Open();
            var sql = $"SELECT * FROM \"Users\" WHERE \"Id\" = @id";
            var result = await conn.QueryAsync<User>(sql, new { id });
            return result.FirstOrDefault();
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
            var profileBD = await GetById(user.Id);

            user.Created = profileBD.Created;
            user.Modified = DateTime.Now;
            user.LastLogin = profileBD.LastLogin;


            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return user;
        }


        
    }
}

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
    public class ProfileRepository : DapperDbContext, IProfileRepository
    {
        private readonly EFDbContext _dbContext;

        public ProfileRepository(IConfiguration configuration, EFDbContext dbContext) : base(configuration)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Profile>> GetAll()
        {
            using IDbConnection conn = DapperConnection;
            conn.Open();
            var sql = "SELECT * FROM \"Profiles\"";
            var result = await conn.QueryAsync<Profile>(sql);
            return result.ToList();
        }

        public async Task<Profile> GetById(Guid id)
        {
            using IDbConnection conn = DapperConnection;
            conn.Open();
            var sql = $"SELECT * FROM \"Profiles\" WHERE \"Id\" = @id";
            var result = await conn.QueryAsync<Profile>(sql, new { id });
            return result.FirstOrDefault();
        }

        public async Task<Profile> Create(Profile profile)
        {
            _dbContext.Add(profile);
            await _dbContext.SaveChangesAsync();
            return profile;
        }

        public async Task Remove(Guid id)
        {
            var profile = GetById(id);
            if (profile != null)
            {
                _dbContext.Remove(profile);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Profile> Update(Profile profile)
        {
            _dbContext.Entry(profile).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return profile;
        }
    }
}
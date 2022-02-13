using DesafioBackend.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace DesafioBackend.Extensions
{
    public static class ProfileClaimsExtension
    {
        public static IList<Claim> GetClaims(this User user)
        {
            var result = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
            };

            result.AddRange(user.Profiles.Select(profile => new Claim(ClaimTypes.Role, profile.Name.ToString())));

            return result;

        }
    }
}

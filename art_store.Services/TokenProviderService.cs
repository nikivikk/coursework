using art_store.Services.Contract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace art_store.Services
{
    public class TokenProviderService : ITokenProviderService
    {
        public string GetClaimValueByType(string accessToken, string claimType)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(accessToken.Split(" ")[1]);

            return jsonToken.Claims.First(claim => claim.Type == ClaimTypes.UserData).Value;
        }
    }
}

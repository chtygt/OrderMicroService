using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Shared.Models;

namespace Services.Shared.Authentication
{
    public class AuthenticationServerHelper
    {
        private readonly AuthenticationOptions _authenticationOptions;

        public AuthenticationServerHelper(IOptions<AuthenticationOptions> authenticationOptions)
        {
            _authenticationOptions = authenticationOptions.Value;
        }

        public TokenResponseModel GenerateToken(string username, int userid)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Convert.FromBase64String(_authenticationOptions.Secret);
                var claimsIdentity = new ClaimsIdentity(new[] {
                    new Claim("UserId", userid.ToString()),
                    new Claim("UserName",username)
                });
                var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claimsIdentity,
                    Issuer = _authenticationOptions.Issuer,
                    Audience = _authenticationOptions.Audience,
                    Expires = DateTime.UtcNow.AddMinutes(60 * 24),
                    SigningCredentials = signingCredentials,

                };
                var secToken = tokenHandler.CreateToken(tokenDescriptor);
                var accesToken = tokenHandler.WriteToken(secToken);
                var token = new TokenResponseModel()
                {
                    UserId = userid,
                    AccessToken = accesToken,
                    RefreshToken = GenerateSecureKey(),
                    AccessTokenExpires = DateTime.UtcNow.AddMinutes(60 * 24),
                    RefreshTokenExpires = DateTime.UtcNow.AddMinutes(60 * 48)
                };

                return token;
            }
            catch (Exception )
            {
                //todo: add logging here
                return null;
            }
        }

        private static string GenerateSecureKey()
        {
            var hmac = new System.Security.Cryptography.HMACSHA256();
            return Convert.ToBase64String(hmac.Key);
        }
    }
}
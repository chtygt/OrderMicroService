using Microsoft.AspNetCore.Http;
using Services.Shared.Models;

namespace Services.Shared.Authentication.Helper
{
    public class HttpContextHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public LoggedUser LoggedUser
        {
            get
            {
                var user = new LoggedUser();
                if (_httpContextAccessor.HttpContext != null)
                {
                    var claims = _httpContextAccessor.HttpContext.User;

                    user.Id = Convert.ToInt32(claims.FindFirst("UserId")?.Value);
                    user.Email = claims.FindFirst("Email")?.Value;
                    user.AccessToken = claims.FindFirst("AccessToken")?.Value;
                    user.RefreshToken = claims.FindFirst("RefreshToken")?.Value;
                    user.RefreshTokenExpires = Convert.ToDateTime(claims.FindFirst("RefreshTokenExpires")?.Value);
                    user.AccessTokenExpires = Convert.ToDateTime(claims.FindFirst("AccessTokenExpires")?.Value);
                }

                return user;
            }
        }
    }
}

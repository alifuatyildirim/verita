using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Verita.Common;

namespace Verita.Application
{
    public class UserClaimService : IUserClaimService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserClaimService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserName()
        {
            var userNameClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name);
            return userNameClaim?.Value;
        }

        public string GetUserFirstName()
        {
            var firstNameClaim = _httpContextAccessor.HttpContext?.User.FindFirst(CustomClaimTypes.GivenName);
            return firstNameClaim?.Value;
        }

        public string GetUserLastName()
        {
            var lastNameClaim = _httpContextAccessor.HttpContext?.User.FindFirst(CustomClaimTypes.Surname);
            return lastNameClaim?.Value;
        }

        public string GetUserAvatarUrl()
        {
            var avatarUrlClaim = _httpContextAccessor.HttpContext?.User.FindFirst(CustomClaimTypes.AvatarURL);
            return avatarUrlClaim?.Value;
        }

        public string GetUserPosition()
        {
            var positionClaim = _httpContextAccessor.HttpContext?.User.FindFirst(CustomClaimTypes.Position);
            return positionClaim?.Value;
        }

        public string GetUserNickName()
        {
            var nickNameClaim = _httpContextAccessor.HttpContext?.User.FindFirst(CustomClaimTypes.NickName);
            return nickNameClaim?.Value;
        }

        public DateTime? GetUserDateRegistered()
        {
            var dateRegisteredClaim = _httpContextAccessor.HttpContext?.User.FindFirst(CustomClaimTypes.DateRegistered);
            if (dateRegisteredClaim != null && DateTime.TryParse(dateRegisteredClaim.Value, out DateTime dateRegistered))
            {
                return dateRegistered;
            }
            return null;
        }
    }
}

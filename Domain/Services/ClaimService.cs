using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Shared.Services.Impl
{
    public interface IClaimService
    {
        string GetUserId();

        string GetClaim(string key);
    }

    public class ClaimService : IClaimService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            return GetClaim(ClaimTypes.NameIdentifier);
        }

        public string GetClaim(string key)
        {
            var claimsIdentity = _httpContextAccessor.HttpContext?.User?.Identity as ClaimsIdentity;
            return claimsIdentity.FindFirst(key)?.Value;
        }
    }
}

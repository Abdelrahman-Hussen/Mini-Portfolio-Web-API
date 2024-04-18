using Microsoft.AspNetCore.Http;

namespace Portfolio.Common.Helpers
{
    public static class Helper
    {
        public static string BaseUrl()
        {
            var httpContextAccessor = new HttpContextAccessor();
            var request = httpContextAccessor.HttpContext!.Request;
            return $"{request.Scheme}://{request.Host}{request.PathBase}/";
        }
    }
}

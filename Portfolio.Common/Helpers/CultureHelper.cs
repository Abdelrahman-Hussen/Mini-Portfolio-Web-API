using Microsoft.AspNetCore.Http;
using Portfolio.Common.Enums;
using Portfolio.Common.Objects;

namespace Portfolio.Common.Helpers
{
    public static class CultureHelper
    {
        public static string? GetCulturedValue(this List<LocalizationObject> source)
        {
            var languge = GetLanguage();

            return source.FirstOrDefault(s => s.Language == languge)?.Content;
        }

        public static Language GetLanguage()
        {
            var httpContextAccessor = new HttpContextAccessor();

            var httpContext = httpContextAccessor.HttpContext;

            string acceptLanguage = httpContext!.Request.Headers["Accept-Language"];

            string lang = acceptLanguage.Split(',').FirstOrDefault()!.Trim().Split(';').FirstOrDefault()!.ToLower();

            if (string.IsNullOrEmpty(lang))
                lang = "en";

            Language language;

            Enum.TryParse(lang, out language);

            return language;
        }
    }
}

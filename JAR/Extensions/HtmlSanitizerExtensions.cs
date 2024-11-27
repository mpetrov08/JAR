using Ganss.Xss;

namespace JAR.Extensions
{
    public static class HtmlSanitizerExtensions
    {
        public static string RemoveHtmlXss(this string html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return string.Empty;

            var sanitizer = new HtmlSanitizer();

            return sanitizer.Sanitize(html);
        }
    }
}

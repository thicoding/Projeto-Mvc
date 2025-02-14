using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Routing;

namespace AppSemTemplate.Extensions
{
    public class RouteSlugifyParameterTransformer : IOutboundParameterTransformer
    {
        public string? TransformOutbound(object? value)
        {
            if (value is null)
            {
                return null;
            }

            // Transform camelCase to kebab-case
            return Regex.Replace(
                value.ToString()!,
                "([a-z])([A-Z])",
                "$1-$2",
                RegexOptions.CultureInvariant,
                TimeSpan.FromMilliseconds(100))
                .ToLowerInvariant();
        }
    }
}
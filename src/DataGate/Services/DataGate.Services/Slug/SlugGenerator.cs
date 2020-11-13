namespace DataGate.Services.Slug
{
    using System;

    public class SlugGenerator : ISlugGenerator
    {
        public string GenerateSlug(string str)
        {
            // Replace spaces with dashes
            str = str.Replace(" ", "-").Replace("--", "-").Replace("--", "-");

            // Remove non-letter characters
            //str = Regex.Replace(str, "[^a-zA-Z0-9_-]+", string.Empty, RegexOptions.Compiled);

            // Trim length to 100 chars
            return str.Substring(0, Math.Min(100, str.Length)).Trim('-');
        }
    }
}

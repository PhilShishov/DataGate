// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Slug
{
    using System;

    public class SlugGenerator : ISlugGenerator
    {
        public string Get(string str)
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

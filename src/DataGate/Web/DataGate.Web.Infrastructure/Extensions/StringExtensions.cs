namespace DataGate.Web.Infrastructure.Extensions
{
    using System.Collections.Generic;
    using System.IO;

    public static class StringExtensions
    {
        private static List<string> specialCharactersNotAllowed = new List<string>
        {
          "/", "\\", "<", ">", ":", "\"", "|", "?", "%", "&", "$", "(", ")", "'"
        };

        public static string ReplaceSpecial(this string s)
        {
            foreach (var c in specialCharactersNotAllowed)
            {
                s = s.Replace(c, "");
            }
            return s;
        }

        public static string GetFileName(string fileName) => Path.GetFileNameWithoutExtension(fileName);
    }
}

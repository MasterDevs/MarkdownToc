using System;
using System.Linq;

namespace MarkdownToc
{
    public class TocGenerator
    {
        public string GenerateSlug(string line)
        {
            return line
                .ToLower()
                .Replace("  ", " ")
                .Replace(":", " ")
                .Replace(' ', '-');
        }

        public string GenerateToc(string md)
        {
            var tocLines = md
                .Split(new[] { "\n", "\r", "\r\n" }, StringSplitOptions.None)
                .Where(line => line.StartsWith("#"))
                .Select(line => ToTocEntry(line));

            return string.Join("\r\n", tocLines);
        }

        private string ToTocEntry(string line)
        {
            var count = line
                .TakeWhile(c => c == '#')
                .Count();

            var cleanLine = line.Trim('#').Trim();

            var indent = new string(' ', (count - 1) * 4);

            var slug = GenerateSlug(cleanLine);

            return $"{indent}* [{cleanLine}](#{slug})";
        }
    }
}
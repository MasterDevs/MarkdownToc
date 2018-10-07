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
    }
}
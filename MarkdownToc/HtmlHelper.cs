using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Text;

namespace MarkdownToc
{
    public class HtmlHelper
    {
        public string AddToc(string html, string toc)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            
            var div = htmlDoc
                .DocumentNode
                .Descendants("div")
                .Where(d => d.HasClass("toc"))
                .FirstOrDefault();

            if (div == null)
            {
                div = HtmlNode.CreateNode($"<div class='toc'></div>");
                htmlDoc.DocumentNode.InsertBefore(div, htmlDoc.DocumentNode.FirstChild);
            }

            div.InnerHtml = "\r\n" + toc + "\r\n";

            htmlDoc.OptionWriteEmptyNodes = true;
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            {
                htmlDoc.Save(sw);
            }
            return sb.ToString();
        }
    }
}
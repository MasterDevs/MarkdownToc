using Xunit;

namespace MarkdownToc.Tests
{
    public class HtmlHelperTests
    {
        [Fact]
        public void AddToc_EmptyHtml_AddsToc()
        {
            // Assemble
            var html = "";
            var expectedHtml = "<div class='toc'>\r\nNew Table Of Contents\r\n</div>";
            var toc = "New Table Of Contents";

            // Act/Assert
            Test(html, expectedHtml, toc);
        }

        [Fact]
        public void AddToc_NoTocExistsInInput_AddsTheToc()
        {
            // Assemble
            const string html = @"Body";

            const string expectedHtml = @"<div class='toc'>
New Table Of Contents
</div>Body";

            const string toc = "New Table Of Contents";

            // Act/Assert
            Test(html, expectedHtml, toc);
        }

        [Fact]
        public void AddToc_TocExistsInInput_UpdatesTheToc()
        {
            // Assemble
            const string htmlWithTwoTocs = @"
<div class='toc'> This is a table of contents </div>

Body";

            const string expectedHtml = @"
<div class='toc'>
New Table Of Contents
</div>

Body";

            const string toc = "New Table Of Contents";

            // Act/Assert
            Test(htmlWithTwoTocs, expectedHtml, toc);
        }

        [Fact]
        public void AddToc_TwoTocsInInput_UpdatesTheFirstToc()
        {
            // Assemble
            const string html = @"
<div class='toc'>
This is a table of contents
</div>

<div class='toc'>
This is a second table of contents
</div>";

            const string expectedHtml = @"
<div class='toc'>
New Table Of Contents
</div>

<div class='toc'>
This is a second table of contents
</div>";

            const string toc = "New Table Of Contents";

            // Act/Assert
            Test(html, expectedHtml, toc);
        }

        private static void Test(string htmlWithTwoTocs, string expectedHtml, string toc)
        {
            var hh = new HtmlHelper();

            // Act
            var actualHtml = hh.AddToc(htmlWithTwoTocs, toc);

            // Assert
            Assert.Equal(expectedHtml, actualHtml);
        }
    }
}
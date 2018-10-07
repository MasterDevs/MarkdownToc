using Xunit;

namespace MarkdownToc.Tests
{
    public class TocGeneratorTests
    {
        [Theory]
        [InlineData("Hello World", "hello-world")]
        [InlineData("Hello    World", "hello--world")]
        [InlineData("Hello: World", "hello--world")]
        public void GenerateSlug(string input, string expected)
        {
            // Assemble
            var generator = new TocGenerator();

            // Act
            var actual = generator.GenerateSlug(input);

            // Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GenerateToc_BlankInput_BlankOutput()
        {
            // Assemble
            var generator = new TocGenerator();
            var md = "";

            // Act
            var actual = generator.GenerateToc(md);

            // Assert
            Assert.Equal("", actual);
        }

        [Fact]
        public void GenerateToc_BalidMarkdownIn_ReturnsToc()
        {
            // Assemble
            var generator = new TocGenerator();

            var md = @"
# One

Body of the first

## Two

Body of the second

# Another One

Another body

## Two: Another Two
";

            var expectedToc = @"
* [One](#one)
    * [Two](#two)
* [Another One](#another-one)
    * [Two: Another Two](#two--another-two)
".Trim();
            // Act
            var actual = generator.GenerateToc(md);

            // Assert
            Assert.Equal(expectedToc, actual);

        }
    }
}
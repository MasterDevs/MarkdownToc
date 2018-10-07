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
    }
}
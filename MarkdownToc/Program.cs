using System;

namespace MarkdownToc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var x = new TocGenerator();
            string toc = x.GenerateToc("");


            Console.WriteLine("Hello World!");
        }
    }
}
using System.Collections.Generic;
using No5.Solution.DocumentPartConverterImplementations;

namespace No5.Solution.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var doc1 = new BoldText {Text = "plain text"};
            var doc2 = new HyperLink {Text = "hyper link", Url = "https://translate.google.com/hl=ru"};
            var doc3 = new PlainText {Text = "plain text"};

            var document = new Document(new DocumentPart[] {doc1, doc2, doc3});

            System.Console.WriteLine(document.ConvertTo(new DocumentPartToHtml()));
            System.Console.WriteLine(document.ConvertTo(new DocumentPartToLaTeX()));
            System.Console.WriteLine(document.ConvertTo(new DocumentPartToPlainText()));
        }
    }
}
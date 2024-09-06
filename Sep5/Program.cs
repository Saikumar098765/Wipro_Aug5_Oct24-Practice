using System;
using System.Linq;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        XDocument xdoc = XDocument.Load("Bookstore.xml");

        var johnDoeBooks = from book in xdoc.Descendants("Book")
                           where (string)book.Element("Author") == "John Doe"
                           select book.Element("Title").Value;

        Console.WriteLine("Books authored by John Doe:");
        foreach (var title in johnDoeBooks)
        {
            Console.WriteLine(title);
        }

        var averagePrice = xdoc.Descendants("Book")
                               .Select(book => (double)book.Element("Price"))
                               .Average();

        Console.WriteLine($"\nAverage price of all books: {averagePrice:C2}");
    }
}

using Books.DataModels;
using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Reflection.Metadata.BlobBuilder;

namespace Books.BLogic
{
    internal class BookHelper
    {
        internal List<Book> BookImport(string []books)
        {
            List<Book> importedBooks = [];
            List<string> tempBooks = books.ToList();
            bool finished = false;
            try 
            {
                while(!finished)
                {
                    importedBooks.Add(
                        new Book(
                            tempBooks[0].Split(':')[1],
                            tempBooks[1].Split(':')[1],
                            tempBooks[2].Split(':')[1],
                            Convert.ToInt16(tempBooks[3].Split(':')[1]),
                            Decimal.Parse(tempBooks[4].Split(':')[1],CultureInfo.InvariantCulture.NumberFormat),
                            tempBooks[5].Split(':')[1]
                            )
                        );
                    if(tempBooks.Count > 6)
                        tempBooks.RemoveRange(0,6);
                    else
                        finished = true;

                    if (tempBooks[0].Contains('*'))
                        tempBooks.RemoveAt(0);
                }
                return importedBooks;
            }
            catch(Exception ex) { Console.WriteLine(ex); }
            return [];
        }

        internal void BookShow(List<Book> list)
        {
            list.ForEach(book =>
            {
                Console.WriteLine(book.Name);
            });
            Console.ReadLine();
        }

        internal bool ExportXML(string path, List<Book> list, string fileName = "")
        {
            try 
            {
                List <Book> tempBooks = list;
                tempBooks.ForEach(book => 
                {
                    book.ISBN = EncryptionData.EncryptionData.Sha256Encrypt(book.ISBN);
                });
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Book>));
                StreamWriter writer = new StreamWriter(path + @"\" + fileName);
                xmlSerializer.Serialize(writer, tempBooks);
                writer.Close();
                return true;
            }
            catch (Exception e) { Console.WriteLine(e); }
            return false;
        }

        internal bool CheckISBN(List<Book> books)
        {
            bool result = false;
            books.ForEach(book =>
            {
                books.ForEach(book2 =>
                {
                    if (book.ISBN == book2.ISBN && book.Name != book.Name)
                        result = true;
                });
            });
            return result;
        }

        internal void GrpByGenre(List<Book> books)
        {
            Console.Clear();
            books.GroupBy(book => book.Genre).ToList().ForEach(b => { 
                Console.WriteLine($"Genre: {b.Key} - Books: {b.Count()}");
            });
            Console.ReadLine();
        }

        internal void WorstPrice(List<Book> books)
        {
            var tempBook = books.MaxBy(book => book.Price);
            Console.Clear();
            Console.WriteLine($"Author: {tempBook.Author} - Name: {tempBook.Name} - Price: {tempBook.Price}");
            Console.ReadLine();
        }

        internal void AvgCostGenre(List<Book> books)
        {
            var avg = books.GroupBy(book => book.Genre).Select( g => new {Genre = g.Key, Avg = g.Average(s => s.Price)});
            Console.Clear();
            foreach (var category in avg)
            {
                Console.WriteLine($"Genre: {category.Genre} - Avg: {category.Avg.ToString("0.00")}");
            }
            Console.ReadLine();
        }

        internal void SearchYear(List<Book> books)
        {
            Console.Clear();
            var tempBooks = books.FindAll(b => b.Year == 2017);
            Console.WriteLine($"Books released in 2017");
            tempBooks.ForEach(book =>
            {
                Console.WriteLine($"Name: {book.Name} - Year: {book.Year} ");
            });

            Console.WriteLine($"\n\nBooks released before 2000");
            tempBooks = books.FindAll(b => b.Year < 2000);
            tempBooks.ForEach(book =>
            {
                Console.WriteLine($"Name: {book.Name} - Year: {book.Year} ");
            });

            Console.WriteLine($"\n\nBooks released after 2000");
            tempBooks = books.FindAll(b => b.Year > 2000);
            tempBooks.ForEach(book =>
            {
                Console.WriteLine($"Name: {book.Name} - Year: {book.Year} ");
            });
            Console.ReadLine();
        }
    }
}

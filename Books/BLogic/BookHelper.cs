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
        internal List<Author> BookImport(string []books)
        {
            List<Book> importedBooks = [];
            List<Author> importedAuthors = [];
            List<string> tempBooks = books.ToList();
            bool finished = false;

            List<Author> tempCheck = [];
            try 
            {
                while (!finished)
                {
                    tempCheck = importedAuthors.FindAll(a => a.Name == tempBooks[1].Split(':')[1]);

                    if (tempCheck.Count == 0)
                    {
                        importedAuthors.Add(
                        new Author(
                            tempBooks[1].Split(':')[1],
                            tempBooks[5].Split(':')[1]
                            )
                        );
                    }

                    if (tempBooks.Count > 6)
                        tempBooks.RemoveRange(0, 6);
                    else
                        finished = true;

                    if (tempBooks[0].Contains('*'))
                        tempBooks.RemoveAt(0);
                }

                finished = false;
                tempBooks = books.ToList();
                while (!finished)
                {
                    Book tempBook = new Book(
                            tempBooks[0].Split(':')[1],
                            tempBooks[2].Split(':')[1],
                            Convert.ToInt16(tempBooks[3].Split(':')[1]),
                            decimal.Parse(tempBooks[4].Split(':')[1], CultureInfo.InvariantCulture.NumberFormat)

                            );
                    tempCheck = importedAuthors.FindAll(a => a.Name == tempBooks[1].Split(':')[1]);

                    tempCheck[0].Books.Add(tempBook);
                    

                    
                    if (tempBooks.Count > 6)
                        tempBooks.RemoveRange(0,6);
                    else
                        finished = true;

                    if (tempBooks[0].Contains('*'))
                        tempBooks.RemoveAt(0);
                }
                
                return importedAuthors;
            }
            catch(Exception ex) { Console.WriteLine(ex); }
            return [];
        }

        internal void ShowAuthors(List<Author> list)
        {
            list.ForEach(author =>
            {
                Console.WriteLine(author.Name);
                author.Books.ForEach(b => Console.WriteLine(b.Name+" "+b.Price));
            });
            Console.ReadLine();
        }

        internal bool ExportXML(string path, List<Author> list, string fileName = "")
        {
            try 
            {
                List <Author> tempAuthor = list;
                tempAuthor.ForEach(a =>
                {
                    a.Books.ForEach(book =>
                    {
                        book.ISBN = EncryptionData.EncryptionData.Sha256Encrypt(book.ISBN);
                    });
                });
                
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Author>));
                StreamWriter writer = new StreamWriter(path + @"\" + fileName);
                xmlSerializer.Serialize(writer, tempAuthor);
                writer.Close();
                return true;
            }
            catch (Exception e) { Console.WriteLine(e); }
            return false;
        }

        internal bool CheckISBN(List<Author> authors)
        {
            bool result = false;
            List<Book> tempBooks = [];
            authors.ForEach(author =>
            {
                author.Books.ForEach(book =>
                {
                    tempBooks.Add(book);
                });
            });

            tempBooks.GroupBy(b => b.ISBN).ToList().ForEach(book =>
            {
                if(book.Count() > 1)
                {
                    Console.WriteLine("ISBN: "+ book.Key+" - Book count: "+book.Count());
                    result = true;
                }
            });
            return result;
        }

        internal void GrpByGenre(List<Author> authors) // not working
        {
            Console.Clear();
            var temp = authors.GroupBy(a => a.Genre).ToList();
            temp.ForEach(a => {
                Console.Write($"Genre: {a.Key} - Numero Libri: ");
                int counter = 0;
                foreach (var b in a)
                {
                    foreach (var c in b.Books) {
                        counter++;
                    }
                }
                Console.WriteLine(counter);
            });
            Console.ReadLine();
        }

        internal void WorstPrice(List<Author> authors)
        {
            Console.Clear();
            var tempBook = authors.Select(b => new {Name = b.Name, Book = b.Books.MaxBy(book => book.Price) });
            List<Book> temp = [];
            foreach (var item in tempBook)
            {
                temp.Add(item.Book);
                
            }
            var temp2 = temp.MaxBy(t => t.Price);

            foreach (var item in tempBook)
            {
                if(temp2 == item.Book) {
                    Console.WriteLine($"Author name: {item.Name} - Book name: {temp2.Name} - Price: {temp2.Price} - ISBN: {temp2.ISBN}");
                }
            }
            Console.ReadLine();
        }

        internal void AvgCostGenre(List<Author> authors)
        {
            var temp = authors.GroupBy(a => a.Genre); //.Select(t => t.Select(t => new { Genre = t.Genre, Avg = t.Books.Average(b => b.Price) }))
            Tuple<string, List<Book>> tempBooks;
            foreach (var t in temp)
            {

                foreach (var t2 in t)
                {
                    //tempBooks.Item1 = t2.Genre;
                    //tempBooks.Item2 = t2.Books;
                    //Console.WriteLine(temp2);
                    Console.ReadLine();
                }
            }


            /*var avg = books.GroupBy(book => book.Genre).Select( g => new {Genre = g.Key, Avg = g.Average(s => s.Price)});
            Console.Clear();
            foreach (var category in avg)
            {
                Console.WriteLine($"Genre: {category.Genre} - Avg: {category.Avg.ToString("0.00")}");
            }
            Console.ReadLine();*/

        }

        /*internal void SearchYear(List<Book> books)
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
        }*/
    }
}

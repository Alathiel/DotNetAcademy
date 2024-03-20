using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataModels
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }

        internal Book() 
        {
            ISBN = string.Empty;
            Author = string.Empty;
            Name = string.Empty;
            Year = 0;
            Price = 0;
            Genre = string.Empty;
        }

        internal Book(string ISBN, string Author, string Name, int Year, decimal Price, string Genre)
        {
            this.ISBN = ISBN;
            this.Author = Author;
            this.Name = Name;
            this.Year = Year;
            this.Price = Price;   
            this.Genre = Genre;
        }
    }
}

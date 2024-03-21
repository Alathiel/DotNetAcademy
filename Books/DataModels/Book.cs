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
        public string Name { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        internal Book() 
        {
            ISBN = string.Empty;
            Name = string.Empty;
            Year = 0;
            Price = 0;
        }

        internal Book(string ISBN, string Name, int Year, decimal Price)
        {
            this.ISBN = ISBN;
            this.Name = Name;
            this.Year = Year;
            this.Price = Price;
        }
    }
}

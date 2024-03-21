using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataModels
{
    public class Author
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public List<Book> Books { get; set;}


        public Author()
        {
            Name = string.Empty;
            Genre = string.Empty;
            Books = [];
        }

        public Author(string Name, string Genre, List<Book> Books)
        {
            this.Name = Name;
            this.Genre = Genre;
            this.Books = Books;
        }
        public Author(string Name, string Genre)
        {
            this.Name = Name;
            this.Genre = Genre;
            Books = [];
        }
    }
}

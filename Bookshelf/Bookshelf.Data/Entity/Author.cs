using System;
using System.Collections.Generic;

namespace Bookshelf.Data.Entity
{
    public class Author : Entity
    {
        public string Name;
        public string Surname;
        public List<Book> Books;       

        public Author()
        {
            Id = Guid.NewGuid();
            Books = new List<Book>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookshelf.Data.Entity
{
    public class Book : Entity
    {
        public string Title;
        public string Publisher;
        public string Category;
        public List<Author> Authors;

        public Book()
        {
            Id = Guid.NewGuid();
            Authors = new List<Author>();
        }
    }
}

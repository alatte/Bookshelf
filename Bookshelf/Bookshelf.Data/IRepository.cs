using Bookshelf.Data.Entity;
using System;
using System.Collections.Generic;


namespace Bookshelf.Data
{
    public interface IRepository
    {
        IEnumerable<Book> Books { get; }
        IEnumerable<Author> Authors { get; }
        IEnumerable<Book_Author> Books_Authors { get; }

        void Add<T>(T entity) where T : Entity.Entity;
        void Delete<T>(T entity) where T : Entity.Entity;

        void SaveChanges();
    }
}

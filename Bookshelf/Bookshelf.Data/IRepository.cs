using Bookshelf.Data.Entity;
using System;
using System.Collections.Generic;


namespace Bookshelf.Data
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<Book> Books { get; }
        IEnumerable<Author> Authors { get; }

        T Get(int id);
        T Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Book GetBookByTitle(string title);

        void SaveChanges();
    }
}

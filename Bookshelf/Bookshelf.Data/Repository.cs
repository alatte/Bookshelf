using System.Collections.Generic;
using System.Linq;
using Bookshelf.Data.Entity;

namespace Bookshelf.Data
{
    public class Repository : IRepository
    {
        BookshelfContext context = new BookshelfContext();

        public IEnumerable<Book> Books
        {
            get
            {
                return context.Books.ToList();
            }
        }

        public IEnumerable<Author> Authors
        {
            get
            {
                return context.Authors.ToList();
            }
        }

        public IEnumerable<Book_Author> Books_Authors
        {
            get
            {
                return context.Books_Authors.ToList();
            }
        }

        public void Add<T>(T entity) where T : Entity.Entity
        {
            this.context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity.Entity
        {
            this.context.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }      
    }
}

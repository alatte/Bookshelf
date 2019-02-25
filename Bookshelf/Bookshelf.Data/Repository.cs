using System.Collections.Generic;
using System.Linq;
using Bookshelf.Data.Entity;

namespace Bookshelf.Data
{
    public class Repository<T> : IRepository<T> where T : class
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

        public T Add(T entity)
        {           
            this.context.Set<T>().Add(entity);
            SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
            SaveChanges();
        }

        public T Get(int id)
        {
            return this.context.Set<T>().Find(id);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Update(T entity)
        {
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            SaveChanges();
        }

        public Book GetBookByTitle(string title)
        {
            return this.context.Books.ToList().First(x => x.Title == title);
        }
    }
}

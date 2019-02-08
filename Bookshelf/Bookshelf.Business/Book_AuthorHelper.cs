using System.Collections.Generic;
using System.Linq;
using Bookshelf.Data;
using Bookshelf.Data.Entity;

namespace Bookshelf.Business
{
    public class Book_AuthorHelper
    {
        private IRepository context;

        public Book_AuthorHelper(IRepository repository)
        {
            this.context = repository;
        }

        public Book_Author AddBook_Author(int book_id, int author_id)
        {
            Book_Author item = new Book_Author() { Book_ID = book_id, Author_ID = author_id };
            context.Add(item);
            context.SaveChanges();
            return item;
        }

        public void DeleteBook_Author(int book_id, int author_id)
        {
            var item = GetBook_Author(book_id, author_id);
            context.Delete(item);
            context.SaveChanges();
        }

        public IEnumerable<Book_Author> GetBooks_Authors()
        {
            return context.Books_Authors.ToList();
        }

        public Book_Author GetBook_Author(int book_id, int author_id)
        {
            return GetBooks_Authors().First(x => x.Book_ID == book_id && x.Author_ID == author_id);
        }
    }
}

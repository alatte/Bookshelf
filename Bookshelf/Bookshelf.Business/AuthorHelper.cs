using System.Collections.Generic;
using System.Linq;
using Bookshelf.Data;
using Bookshelf.Data.Entity;


namespace Bookshelf.Business
{
    public class AuthorHelper
    {
        private IRepository context;

        public AuthorHelper(IRepository repository)
        {
            this.context = repository;
        }

        public Author AddAuthor(string name, string surname)
        {
            Author item = new Author() { Name = name, Surname = surname };
            context.Add(item);
            context.SaveChanges();
            return item;
        }

        public void DeleteAuthor(int id)
        {
            var item = GetAuthor(id);
            context.Delete(item);
            context.SaveChanges();
        }

        public Author EditAuthor(int id, string name, string surname)
        {
            var item = GetAuthor(id);
            item.Name = name;
            item.Surname = surname;
            context.SaveChanges();
            return item;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return context.Authors.ToList();
        }

        public IEnumerable<Author> GetAuthorsByBook(int book_id)
        {
            var authorsSelected = (from ba in context.Books_Authors where ba.Book_ID == book_id select ba.Author_ID).ToList();
            return from a in context.Authors where authorsSelected.Contains(a.Author_ID) select a;
        }

        public Author GetAuthor(int id)
        {
            return GetAuthors().First(x => x.Author_ID == id);
        }
    }
}

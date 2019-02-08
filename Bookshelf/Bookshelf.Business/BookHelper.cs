using System;
using System.Collections.Generic;
using System.Linq;
using Bookshelf.Data;
using Bookshelf.Data.Entity;

namespace Bookshelf.Business
{
    public class BookHelper
    {
        private IRepository context;
        private AuthorHelper AuthorHelper;
        private Book_AuthorHelper Book_AuthorHelper;

        public BookHelper(IRepository repository)
        {
            this.context = repository;
            AuthorHelper = new AuthorHelper(repository);
            Book_AuthorHelper = new Book_AuthorHelper(repository);
        }
      
        public Book AddBook(string title, string publisher, string category)
        {
            Book item = new Book() { Title = title, Publisher = publisher, Category = category };
            context.Add(item);
            context.SaveChanges();
            return item;
        }

        public void DeleteBook(int id)
        {
            var item = GetBook(id);
            context.Delete(item);
            foreach (Author a in AuthorHelper.GetAuthorsByBook(id))
                AuthorHelper.DeleteAuthor(a.Author_ID);
            context.SaveChanges();
        }

        public Book EditBook(Book book, string title, string publisher, string category)
        {            
            book.Title = title;
            book.Publisher = publisher;
            book.Category = category;
            context.SaveChanges();
            return book;
        }

        public IEnumerable<Book> GetBooks()
        {
            return context.Books.ToList();
        }

        public IEnumerable<Book> GetBooksByAuthor(int author_id)
        {
            var booksSelected = (from ba in context.Books_Authors where ba.Author_ID == author_id select ba.Book_ID).ToList();
            return from b in context.Books where booksSelected.Contains(b.Book_ID) select b;
        }

        public Book GetBook(int id)
        {
            return GetBooks().First(x => x.Book_ID == id);
        }

        public Book GetBook(string title)
        {
            return GetBooks().First(x => x.Title == title);
        }

        public Book_Author AddAuthorForBook(int book_id, string name, string surname)
        {
            Author author = AuthorHelper.AddAuthor(name, surname);
            return Book_AuthorHelper.AddBook_Author(book_id, author.Author_ID);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookshelf.Data;
using Bookshelf.Data.Entity;

namespace Bookshelf.App
{
    class Program
    {
        static Repository<Book> BookRepo = new Repository<Book>();
        static Repository<Author> AuthorRepo = new Repository<Author>();

        static void Main(string[] args)
        {
            BookRepo.AddAuthorForBook(BookRepo.Add(new Book { Title = "Harry Potter and the Deathly Hallows", Publisher = "Rosmen", Category = "Fantasy" }), AuthorRepo.Add(new Author { Name = "Joahn", Surname = "Roaling" })); 

            WriteBooks();

            Book book = BookRepo.GetBookByTitle("Harry Potter and the Deathly Hallows");
            book.Title = "Harry Potter and the Prisoner of Azkaban";
            BookRepo.Update(book);

            WriteBooks();

            BookRepo.Delete(BookRepo.GetBookByTitle("Harry Potter and the Prisoner of Azkaban"));
            WriteBooks();

            Console.ReadKey();
        }

        static void WriteBooks()
        {
            foreach (Book b in BookRepo.Books)
            {
                Console.Write($"\"{b.Title}\" - ");
                foreach (Author a in AuthorRepo.GetAuthorsByBook(b.Book_ID))
                    Console.WriteLine($"{a.Name} {a.Surname};");
            }
            Console.WriteLine(new string('=', 20));
        }
    }
}

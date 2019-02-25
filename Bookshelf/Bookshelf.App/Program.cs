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
            Book book;
            Author author;
            book = BookRepo.Add(new Book { Title = "Harry Potter and the Deathly Hallows", Publisher = "Rosmen", Category = "Fantasy" });
            BookRepo.Add(new Book { Title = "Anna Dmitrieva and the Fucking Diploma", Publisher = "Rosmen", Category = "Fantasy" }).Authors.Add(new Author { Name = "Anna", Surname = "Dmitrieva"});
            author = AuthorRepo.Add(author = new Author { Name = "Joahn", Surname = "Roaling" });
            author.Books.Add(book);
            book.Authors.Add(author);

            WriteBooks();

            book = BookRepo.GetBookByTitle("Harry Potter and the Deathly Hallows");
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
                foreach (Author a in b.Authors)
                    Console.WriteLine($"{a.Name} {a.Surname};");
            }
            Console.WriteLine(new string('=', 20));
        }
    }
}

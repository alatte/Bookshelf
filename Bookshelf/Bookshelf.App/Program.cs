using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookshelf.Data;
using Bookshelf.Data.Entity;
using Bookshelf.Business;

namespace Bookshelf.App
{
    class Program
    {
        static BookHelper BookHelper = new BookHelper(new Repository());
       
        static void Main(string[] args)
        {
            BookHelper.AddAuthorForBook(BookHelper.AddBook("Harry Potter and the Deathly Hallows", "Rosmen", "Fantasy").Book_ID, 
                                                           "Joahn", "Roaling");
            WriteBooks();

            BookHelper.EditBook(BookHelper.GetBook("Harry Potter and the Deathly Hallows"), 
                                                   "Harry Potter and the Prisoner of Azkaban", "Rosmen", "Fantasy");
            WriteBooks();

            BookHelper.DeleteBook(BookHelper.GetBook("Harry Potter and the Prisoner of Azkaban").Book_ID);
            WriteBooks();

            Console.ReadKey();
        }

        static void WriteBooks()
        {
            AuthorHelper AuthorHelper = new AuthorHelper(new Repository());

            foreach (Book b in BookHelper.GetBooks())
            {
                Console.Write($"\"{b.Title}\" - ");
                foreach (Author a in AuthorHelper.GetAuthorsByBook(b.Book_ID))
                    Console.WriteLine($"{a.Name} {a.Surname};");
            }
            Console.WriteLine(new string('=', 20));
        }
    }
}

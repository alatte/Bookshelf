using Bookshelf.Data.Entity;
using System.Data.Entity;

namespace Bookshelf.Data
{
    class BookshelfContext : DbContext
    {
        public BookshelfContext():base("DefaultConnection")
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Books_Authors { get; set; }
    }
}

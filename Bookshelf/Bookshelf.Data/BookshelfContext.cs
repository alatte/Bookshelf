using Bookshelf.Data.Entity;
using System.Data.Entity;

namespace Bookshelf.Data
{
    class BookshelfContext : DbContext
    {
        public BookshelfContext() : base ("BookshelfConnection")
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}

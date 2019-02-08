using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookshelf.Data.Entity
{
    public class Book_Author : Entity
    {
        [Key, Column(Order = 0)]
        public int Book_ID { get; set; }
        [Key, Column(Order = 1)]
        public int Author_ID { get; set; }
    }
}

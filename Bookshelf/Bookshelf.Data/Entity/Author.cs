using System.ComponentModel.DataAnnotations;

namespace Bookshelf.Data.Entity
{
    public class Author : Entity
    {
        [Key]
        public int Author_ID { get; set; }

        private string name;
        private string surname;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name" +
                    "");
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Bookshelf.Data.Entity
{
    public class Book : Entity
    {
        [Key]
        public int Book_ID { get; set; }

        private string title;
        private string publisher;
        private string category;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Publisher
        {
            get { return publisher; }
            set
            {
                publisher = value;
                OnPropertyChanged("Publisher");
            }
        }

        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged("Category");
            }
        }
    }
}

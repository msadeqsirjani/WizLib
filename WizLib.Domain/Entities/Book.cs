using WizLib.Domain.Common;

namespace WizLib.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Isbn { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public int BookDetailId { get; set; }
        public int PublisherId { get; set; }

        public Category Category { get; set; }
        public BookDetail BookDetail { get; set; }
        public Publisher Publisher { get; set; }
    }
}

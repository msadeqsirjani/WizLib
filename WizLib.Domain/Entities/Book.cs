using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WizLib.Domain.Common;

namespace WizLib.Domain.Entities
{
    public class Book : BaseEntity
    {
        [Required, StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }
        [Required, StringLength(16, MinimumLength = 4)]
        public string Isbn { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public int? BookDetailId { get; set; }
        public int PublisherId { get; set; }

        public Category Category { get; set; }
        public BookDetail BookDetail { get; set; }
        public Publisher Publisher { get; set; }
        public List<AuthorBook> AuthorBooks { get; set; }
    }
}

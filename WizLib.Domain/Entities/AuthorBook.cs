using WizLib.Domain.Common;

namespace WizLib.Domain.Entities
{
    public class AuthorBook : BaseEntity
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}

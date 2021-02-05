using WizLib.Domain.Common;

namespace WizLib.Domain.Entities
{
    public class BookDetail : BaseEntity
    {
        public int NumberOfChapters { get; set; }
        public int NumberOfPages { get; set; }
        public double? Weight { get; set; }

        public Book Book { get; set; }
    }
}

using WizLib.Domain.Common;

namespace WizLib.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Isbn { get; set; }
        public double Price { get; set; }
    }
}

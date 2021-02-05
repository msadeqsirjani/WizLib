using WizLib.Domain.Common;

namespace WizLib.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
    }
}

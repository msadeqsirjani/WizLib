using WizLib.Domain.Common;

namespace WizLib.Domain.Entities
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
}

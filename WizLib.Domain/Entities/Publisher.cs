using System.Collections.Generic;
using WizLib.Domain.Common;

namespace WizLib.Domain.Entities
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public List<Book> Books { get; set; }
    }
}

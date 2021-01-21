using System.Collections.Generic;
using WizLib.Domain.Common;

namespace WizLib.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }

        public List<Book> Books { get; set; }
    }
}

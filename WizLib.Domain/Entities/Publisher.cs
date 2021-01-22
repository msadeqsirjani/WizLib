using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WizLib.Domain.Common;

namespace WizLib.Domain.Entities
{
    public class Publisher : BaseEntity
    {
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string Location { get; set; }

        public List<Book> Books { get; set; }
    }
}

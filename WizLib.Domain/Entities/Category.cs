using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WizLib.Domain.Common;

namespace WizLib.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required, StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }

        public List<Book> Books { get; set; }
    }
}

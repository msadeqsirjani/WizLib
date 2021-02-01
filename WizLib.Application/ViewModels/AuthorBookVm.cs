using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WizLib.Domain.Entities;

namespace WizLib.Application.ViewModels
{
    public class AuthorBookVm
    {
        public AuthorBook AuthorBook { get; set; }
        public Book Book { get; set; }
        public IEnumerable<AuthorBook> AuthorBooks { get; set; }
        public IEnumerable<SelectListItem> Authors { get; set; }
    }
}

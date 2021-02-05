using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WizLib.Domain.Entities;

namespace WizLib.Application.ViewModels
{
    public class BookVm
    {
        public Book Book { get; set; }
        public List<SelectListItem> Publishers { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}

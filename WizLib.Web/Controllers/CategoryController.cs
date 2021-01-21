using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WizLib.Infra.Data.Persistence;

namespace WizLib.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var categories = _db.Categories.ToList();

            return View(categories);
        }
    }
}

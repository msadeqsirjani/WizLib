using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
    }
}

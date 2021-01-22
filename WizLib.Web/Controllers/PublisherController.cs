using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WizLib.Domain.Entities;
using WizLib.Infra.Data.Persistence;

namespace WizLib.Web.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PublisherController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var publishers = _db.Publishers.ToList();

            return View(publishers);
        }

        public IActionResult Upsert(int? id)
        {
            if (id.HasValue)
            {
                var publisher = _db.Publishers.FirstOrDefault(x => x.Id == id);

                return View(publisher);
            }
            else
            {
                var publisher = new Publisher();

                return View(publisher);
            }
        }
    }
}

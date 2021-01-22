using Microsoft.AspNetCore.Mvc;
using System;
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
                var publisher = _db.Publishers.FirstOrDefault(x => x.Id == id.GetValueOrDefault());

                if (publisher == null)
                    return NotFound();

                return View(publisher);
            }
            else
            {
                var publisher = new Publisher
                {
                    Name = Guid.NewGuid().ToString(),
                    Location = Guid.NewGuid().ToString()
                };

                return View(publisher);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Publisher publisher)
        {
            if (!ModelState.IsValid)
                return View(publisher);

            if (publisher.Id == 0)
            {
                _db.Publishers.Add(publisher);
            }
            else
            {
                _db.Update(publisher);
            }

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var publisher = _db.Publishers.FirstOrDefault(x => x.Id == id);

            if (publisher == null)
                return NotFound();

            _db.Publishers.Remove(publisher);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}

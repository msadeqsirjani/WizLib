using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WizLib.Application.Seed;
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
                    Name = PublisherInitializer.Seed(),
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

        public IActionResult CreateMultiple2()
        {
            var publishers = new List<Publisher>();

            for (var i = 0; i < 2; i++)
            {
                publishers.Add(new Publisher()
                {
                    Name = PublisherInitializer.Seed(),
                    Location = Guid.NewGuid().ToString()
                });
            }

            _db.Publishers.AddRange(publishers);

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple5()
        {
            var publishers = new List<Publisher>();

            for (var i = 0; i < 5; i++)
            {
                publishers.Add(new Publisher
                {
                    Name = PublisherInitializer.Seed(),
                    Location = Guid.NewGuid().ToString()
                });
            }

            _db.Publishers.AddRange(publishers);

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple2()
        {
            var publishers = _db.Publishers.OrderBy(x => Guid.NewGuid()).Take(2);

            _db.Publishers.RemoveRange(publishers);

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple5()
        {
            var publishers = _db.Publishers.OrderBy(x => Guid.NewGuid()).Take(5);

            _db.Publishers.RemoveRange(publishers);

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}

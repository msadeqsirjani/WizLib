using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WizLib.Domain.Entities;
using WizLib.Infra.Data.Persistence;

namespace WizLib.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var authors = _db.Authors.ToList();

            return View(authors);
        }

        public IActionResult Upsert(int? id)
        {
            if (id.HasValue)
            {
                var author = _db.Authors.FirstOrDefault(x => x.Id == id);
                if (author == null)
                    return NotFound();

                return View(author);
            }
            else
            {
                var random = new Random();

                var days = random.Next(-16384 * 2, 0);

                var author = new Author
                {
                    Forename = Guid.NewGuid().ToString(),
                    Surname = Guid.NewGuid().ToString(),
                    Location = Guid.NewGuid().ToString(),
                    Birthdate = DateTime.Now.AddDays(days)
                };

                return View(author);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Author author)
        {
            if (!ModelState.IsValid)
                return View(author);

            if (author.Id.IsDefault())
            {
                _db.Authors.Add(author);
            }
            else
            {
                _db.Authors.Update(author);
            }

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var author = _db.Authors.FirstOrDefault(x => x.Id == id);

            if (author == null)
                return NotFound();

            _db.Authors.Remove(author);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple2()
        {
            var authors = new List<Author>();

            var random = new Random();
            for (var i = 0; i < 2; i++)
            {
                var days = random.Next(-16384 * 2, 0);

                authors.Add(new Author()
                {
                    Forename = Guid.NewGuid().ToString(),
                    Surname = Guid.NewGuid().ToString(),
                    Location = Guid.NewGuid().ToString(),
                    Birthdate = DateTime.Now.AddDays(days)
                });
            }

            _db.Authors.AddRange(authors);

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple5()
        {
            var authors = new List<Author>();

            var random = new Random();
            for (var i = 0; i < 5; i++)
            {
                var days = random.Next(-16384 * 2, 0);
                authors.Add(new Author()
                {
                    Forename = Guid.NewGuid().ToString(),
                    Surname = Guid.NewGuid().ToString(),
                    Location = Guid.NewGuid().ToString(),
                    Birthdate = DateTime.Now.AddDays(days)
                });
            }

            _db.Authors.AddRange(authors);

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple2()
        {
            var authors = _db.Authors.OrderBy(x => Guid.NewGuid()).Take(2);

            _db.Authors.RemoveRange(authors);

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple5()
        {
            var authors = _db.Authors.OrderBy(x => Guid.NewGuid()).Take(5);

            _db.Authors.RemoveRange(authors);

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}

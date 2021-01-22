using Microsoft.AspNetCore.Mvc;
using System;
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
                var random = new Random(DateTime.Now.Ticks.ToInt32());

                var days = random.Next(-16384, 16384);

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
    }
}

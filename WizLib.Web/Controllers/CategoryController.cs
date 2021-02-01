using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WizLib.Application.Seed;
using WizLib.Domain.Entities;
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

        public IActionResult Upsert(int? id)
        {
            if (id.HasValue)
            {
                var category = _db.Categories.FirstOrDefault(x => x.Id == id.GetValueOrDefault());

                if (category == null)
                    return NotFound();

                return View(category);
            }
            else
            {
                var category = new Category()
                {
                    Title = CategoryInitializer.Seed()
                };

                return View(category);
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (!ModelState.IsValid)
                return View(category);

            if (category.Id == 0)
            {
                _db.Categories.Add(category);
            }
            else
            {
                _db.Categories.Update(category);
            }

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (!id.HasValue || id.Value == 0)
                return NotFound();

            var category = _db.Categories.FirstOrDefault(x => x.Id == id.GetValueOrDefault());

            if (category == null)
                return NotFound();

            _db.Categories.Remove(category);

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple2()
        {
            var categories = new List<Category>();

            for (var i = 0; i < 2; i++)
            {
                categories.Add(new Category
                {
                    Title = CategoryInitializer.Seed()
                });
            }

            _db.Categories.AddRange(categories);

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple5()
        {
            var categories = new List<Category>();

            for (var i = 0; i < 5; i++)
            {
                categories.Add(new Category
                {
                    Title = CategoryInitializer.Seed()
                });
            }

            _db.Categories.AddRange(categories);

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple2()
        {
            var categories = _db.Categories.OrderBy(x => Guid.NewGuid()).Take(2);

            _db.Categories.RemoveRange(categories);

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple5()
        {
            var categories = _db.Categories.OrderBy(x => Guid.NewGuid()).Take(5);

            _db.Categories.RemoveRange(categories);

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}

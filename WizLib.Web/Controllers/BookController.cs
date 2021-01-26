﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WizLib.Application.ViewModels;
using WizLib.Domain.Entities;
using WizLib.Infra.Data.Persistence;

namespace WizLib.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var books = _db.Books
                .Include(x => x.Publisher)
                .Include(x => x.Authors)
                .ToList();

            return View(books);
        }

        public IActionResult Upsert(int? id)
        {
            var publishers = _db.Publishers.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            var categories = _db.Categories.Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.Id.ToString()
            }).ToList();

            if (!id.HasValue)
            {
                var random = new Random();

                var bookVm = new BookVm
                {
                    Book = new Book
                    {
                        Title = Guid.NewGuid().ToString(),
                        Price = random.Next(15000, 150000),
                        Isbn = Guid.NewGuid().ToString("N")[..16]
                    },
                    Publishers = publishers,
                    Categories = categories
                };

                return View(bookVm);
            }
            else
            {
                var book = _db.Books.FirstOrDefault(x => x.Id == id);

                if (book == null)
                    return NotFound();

                var bookVm = new BookVm
                {
                    Book = book,
                    Publishers = publishers,
                    Categories = categories
                };

                return View(bookVm);
            }
        }

        [HttpPost]
        public IActionResult Upsert(BookVm bookVm)
        {
            if (!ModelState.IsValid)
                return View(bookVm);

            if (bookVm.Book.Id.IsDefault())
            {
                _db.Books.Add(bookVm.Book);
            }
            else
            {
                _db.Books.Update(bookVm.Book);
            }

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var book = _db.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
                return NotFound();

            _db.Books.Remove(book);

            return RedirectToAction(nameof(Index));
        }
    }
}
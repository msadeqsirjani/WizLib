﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WizLib.Application.Seed;
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
                .Include(x => x.AuthorBooks)
                .ThenInclude(x => x.Author)
                .OrderBy(x => x.Price)
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
                        Title = BookInitializer.Seed(),
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
                _db.Books.Attach(bookVm.Book);
            }

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            var categories = _db.Categories.Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.Id.ToString()
            }).ToList();

            var random = new Random();

            var book = _db.Books.Include(x => x.BookDetail).FirstOrDefault(x => x.Id == id);

            if (book == null)
                return NotFound();

            var bookVm = new BookVm
            {
                Book = book,
                Categories = categories
            };

            bookVm.Book.BookDetail = new BookDetail
            {
                NumberOfChapters = random.Next(0, 20) + 5,
                NumberOfPages = random.Next(0, 1000) + 100,
                Weight = (random.NextDouble() + 250.0).Round(3, MidpointRounding.ToEven)
            };

            return View(bookVm);
        }

        [HttpPost]
        public IActionResult Details(BookVm bookVm)
        {
            if (bookVm.Book.BookDetail.Id.IsDefault())
            {
                _db.BookDetails.Add(bookVm.Book.BookDetail);
                _db.SaveChanges();

                var book = _db.Books.FirstOrDefault(x => x.Id == bookVm.Book.Id);

                if (book == null)
                    return NotFound();

                book.BookDetailId = bookVm.Book.BookDetail.Id;
                _db.SaveChanges();
            }
            else
            {
                _db.BookDetails.Update(bookVm.Book.BookDetail);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var book = _db.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
                return NotFound();

            _db.Books.Remove(book);

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ManageAuthors(int id)
        {
            var authorBookVm = new AuthorBookVm
            {
                AuthorBooks = _db.AuthorBooks
                    .Include(x => x.Author)
                    .Include(x => x.Book)
                    .Where(x => x.BookId == id)
                    .ToList(),
                AuthorBook = new AuthorBook()
                {
                    BookId = id
                },
                Book = _db.Books.FirstOrDefault(x => x.Id == id)
            };

            var authorsId = authorBookVm.AuthorBooks.Select(x => x.AuthorId).ToList();

            var authors = _db.Authors.Where(x => !authorsId.Contains(x.Id)).ToList();

            authorBookVm.Authors = authors.Select(x => new SelectListItem()
            {
                Text = x.Fullname,
                Value = x.Id.ToString()
            });

            return View(authorBookVm);
        }

        [HttpPost]
        public IActionResult ManageAuthors(AuthorBookVm authorBookVm)
        {
            if (authorBookVm.AuthorBook.BookId == 0 || authorBookVm.AuthorBook.AuthorId == 0)
                return RedirectToAction(nameof(ManageAuthors), new { id = authorBookVm.AuthorBook.BookId });

            _db.AuthorBooks.Add(authorBookVm.AuthorBook);
            _db.SaveChanges();

            return RedirectToAction(nameof(ManageAuthors), new { @id = authorBookVm.AuthorBook.BookId });
        }

        [HttpPost]
        public IActionResult RemoveAuthors([FromRoute] int id, AuthorBookVm authorBookVm)
        {
            var bookId = authorBookVm.Book.Id;
            var authorBook = _db.AuthorBooks.FirstOrDefault(x => x.AuthorId == id && x.BookId == bookId);

            if (authorBook == null)
                return NotFound();

            _db.AuthorBooks.Remove(authorBook);
            _db.SaveChanges();

            return RedirectToAction(nameof(ManageAuthors), new { id = bookId });
        }

        public IActionResult PlayGround()
        {
            var category = _db.Categories.FirstOrDefault();
            _db.Entry(category).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}

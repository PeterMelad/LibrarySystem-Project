using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Services;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        [TempData]
        public string ErrorMessage { get; set; }
        IBooksrepo Book;
        IAuthorRepo author;
        public BookController(IBooksrepo Book,IAuthorRepo author)
        {
            this.Book = Book;
            this.author = author;
        }
        public IActionResult Index()
        {
            ViewBag.author = author.getall();
            return View(Book.getall());
        }

        public IActionResult CreateBook(string AuthorName)
        {
            if (AuthorName != null)
            {
                ViewBag.AuthorName = author.FindByName(AuthorName);
             //   Books B = new Books();
             //   B.author= author.FindByName(AuthorName);
             //ViewBag.author = author.getall();
             //   return View(B);
            }
           
             ViewBag.author = author.getall();
            return View();
        }
        [HttpPost]
        public IActionResult CreateBook(Books new_b ,int id)
        {
           // if (ModelState.IsValid)
            {
                Book.AddBook(new_b);
                return RedirectToAction("Index");
            }
           // return View();

        }

        public IActionResult Delete(int id)
        {
            if (Book.FindBook(id) != null)
            {
                Book.DelBook(id);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("id", "Invalid parameter");
            return RedirectToAction("Index");

        }
        public IActionResult Details(int id)
        {
            if (Book.FindBook(id)!=null)
            {
                ViewBag.author = author.getall();
                Books b = Book.FindBook(id);
                return View(b);
            }
            ModelState.AddModelError(string.Empty, "Invalid parameter");
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            if (Book.FindBook(id) != null)
            {
                return View(Book.FindBook(id));
            }
            ModelState.AddModelError(string.Empty, "Invalid Parameter");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Books b)
        {
            
            if (ModelState.IsValid)
            {
                Book.EditBook(b);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

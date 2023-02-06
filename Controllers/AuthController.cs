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
    public class AuthController : Controller
    {
        IAuthorRepo Author;
        IBooksrepo books;
        public AuthController(IAuthorRepo Author, IBooksrepo books)
        {
            this.Author = Author;
            this.books = books;
        }

        public IActionResult Index()
        {
            ViewBag.books = books.getall();             //3mlt el line da 3l4an a3rf ast5dm property " IEnumerable<Books> book " ele mawgoda fe class el author,ast5dmha fe el view page 3latol (mn 8er ma a7tag ast5dm ViewBag)
            return View(Author.getall());
        }
     
        public IActionResult Delete(int id)
        {
            if (Author.FindAuthor(id) != null)
            {
                Author.DelAuthor(id);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Invalid parameter");
            return RedirectToAction("Index");
        }

        public IActionResult CreateAuthor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAuthor([Bind(include:"Name, Describtion")] Authors a)
        {
            
            //if (ModelState.IsValid)
            {
                Author.AddAuthor(a);
                return RedirectToAction("CreateBook", "Book",new { AuthorName= a.Name});
            }
            //return View();
        }

        public IActionResult Details(int id)
        {
            if (Author.FindAuthor(id)!=null)
            {
                ViewBag.books = books.getall();
                return View(Author.FindAuthor(id));
            }
            ModelState.AddModelError(string.Empty, "Invalid parameter");
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            if (Author.FindAuthor(id) != null)
            {
                ViewBag.books = books.getall();
                return View(Author.FindAuthor(id));
            }
            ModelState.AddModelError(string.Empty, "Invalid parameter");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Authors a)
        {
            if (ModelState.IsValid)
            {
                Author.EditAuthor(a);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

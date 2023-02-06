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
    public class BorrowersController : Controller
    {
        IBorrowing Borrowing;
        BorrowingBookRepo bbR;
        IBooksrepo Book;
        public BorrowersController(IBorrowing Borrowing, BorrowingBookRepo bbR, IBooksrepo Book)
        {
            this.Borrowing = Borrowing;
            this.bbR = bbR;
            this.Book = Book;
        }
        public IActionResult Index()
        {
            ViewBag.BorrowingBook = bbR.GetAll();
            ViewBag.Book = Book.getall();                        // ana 7tet el two lines dool 3l4an a3rf a2ra el data bta3thom fe form el index
            return View(Borrowing.GetAll());
        }

        public IActionResult Delete(int id)
        {
            ViewBag.BorrowinBook = bbR.GetAll();        // lazeem a3ml el line da 3l4an tsm3 fe fe function del fe el repo (lw 4lt el line da ,hy2ol list "BorrowingBook" ele f Borrowers b null *
            if (Borrowing.FindBorrower(id) != null)
            {
            Borrowing.DelBorrower(id);
            return RedirectToAction("Index");
            }
           
            return RedirectToAction("Index");
        }

        public  IActionResult Create()
        {
            ViewBag.Book = Book.getall();
            ViewBag.BorrowingBook = bbR.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Borrower b)
        {
            if (ModelState.IsValid)
            {
                Borrowing.AddBorrower(b);
                return RedirectToAction("Index");
            }
            return View(b);
        }
        public IActionResult Details(int id)
        {
            if (Borrowing.FindBorrower(id) != null)
            {
                ViewBag.Book = Book.getall();
                ViewBag.BorrowingBook = bbR.GetAll();
                return View(Borrowing.FindBorrower(id));
            }
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            if (Borrowing.FindBorrower(id) != null)
            {
                ViewBag.Book = Book.getall();
                ViewBag.BorrowingBook = bbR.GetAll();
                return View(Borrowing.FindBorrower(id));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Borrower b)
        {
            ViewBag.BorrowingBook = bbR.GetAll();
            if (ModelState.IsValid)
            {
                Borrowing.EditBorrower(b);
                return RedirectToAction("Index");
            }
            return View(b);
        }
    }
}

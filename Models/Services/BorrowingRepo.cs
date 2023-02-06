using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Models.Services
{
    public class BorrowingRepo:IBorrowing
    {
        ApplicationDbContext db;
        BorrowingBookRepo BBR;
        IBooksrepo B;
        public BorrowingRepo(ApplicationDbContext db, BorrowingBookRepo BBR, IBooksrepo B)
        {
            this.db = db;
            this.BBR = BBR;
            this.B = B;
        }

        public List<Borrower> GetAll()
        {
            return db.Borrowers.ToList();
        }

        public void AddBorrower(Borrower b)
        {

            BorrowBook BoB = new BorrowBook();
            BoB.BookID = b.BookID;
            BoB.Book = B.FindBook(b.BookID);
            BoB.BorrowerID = b.id;
            BoB.Borrower = b;
            b.BorrowBooks = new List<BorrowBook>();
            b.BorrowBooks.Add(BoB);
            BoB.Book.BookCount--;

            db.Borrowers.Add(b);
            db.SaveChanges();
        }
        public Borrower FindBorrower(int id)
        {
            return db.Borrowers.Find(id);
        }
        public void EditBorrower(Borrower b)
        {
            Borrower new_b = FindBorrower(b.id);
            BorrowBook bb;
            if (b.BookToRemove != 0)
            {
                bb = BBR.GetBorrowBook(b.BookToRemove);
                B.FindBook(b.BookToRemove).BookCount++;
               
                new_b.BorrowBooks.Remove(bb);

            }
            if (b.BookID != 0)
            {
                bb = new BorrowBook() { BookID = b.BookID, BorrowerID = new_b.id, Borrower = new_b, Book = B.FindBook(b.BookID) };
                new_b.BorrowBooks.Add(bb);
                B.FindBook(b.BookID).BookCount--;
            }
            new_b.Name = b.Name;
            new_b.DateOfBorrow = b.DateOfBorrow;
            new_b.DateOfRecieve = b.DateOfRecieve;
            db.Entry(new_b).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
           
        }
        public void DelBorrower(int id)
        {
            Borrower b = FindBorrower(id);
            foreach (var item in b.BorrowBooks)
            {
                B.FindBook(item.BookID).BookCount++;
            }

            db.Borrowers.Remove(b);
            db.SaveChanges();
        }


    }
}

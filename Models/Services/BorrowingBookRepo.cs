using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Models.Services
{
    public class BorrowingBookRepo
    {
        ApplicationDbContext db;
        public BorrowingBookRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public List<BorrowBook> GetAll()
        {
            return db.BorrowBooks.ToList();
        }
        public  BorrowBook GetBorrowBook(int id)
        {
          return  db.BorrowBooks.SingleOrDefault(ee => ee.BookID == id);
        }

    }
}

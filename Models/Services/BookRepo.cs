using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Models.Services
{
    public class BookRepo : IBooksrepo
    {
        ApplicationDbContext db;
        public BookRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void AddBook(Books b)
        {
            b.author = db.auhors.Find(b.author.id);            
            db.books.Add(b);            // m4 3ayz y map author id fe el book m3 el author 
            db.SaveChanges();
        }

        public void DelBook(int id)
        {
            db.books.Remove(FindBook(id));
            db.SaveChanges();
        }

        public void EditBook( Books b)
        {
            Books newb = db.books.SingleOrDefault(ee => ee.id == b.id);
            newb.Edition = b.Edition;
            newb.Title = b.Title;
            newb.author = b.author;
            db.Entry(newb).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

        }
        public Books FindBook(int id)
        {
            return db.books.Find(id);
        }
        public List<Books> getall()
        {
           return db.books.ToList();
        }
    }
}

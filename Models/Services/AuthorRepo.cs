using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Models.Services
{
    public class AuthorRepo : IAuthorRepo
    {
        ApplicationDbContext db;
        public AuthorRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void AddAuthor(Authors a)
        {
          
            db.auhors.Add(a);
            db.SaveChanges();
        }

        public void DelAuthor(int id)
        {
            db.auhors.Remove(FindAuthor(id));
            db.SaveChanges();
        }

        public void EditAuthor( Authors a)
        {
            Authors auth = db.auhors.FirstOrDefault(aa => aa.id == a.id);
            auth.Name = a.Name;
            auth.Describtion = a.Describtion;
            db.Entry(auth).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public List<Authors> getall()
        {
            return db.auhors.ToList();
        }
        public Authors FindAuthor(int id)
        {
            return db.auhors.Find(id);
        }
        public Authors FindByName(string Name)
        {
            return db.auhors.FirstOrDefault(ee => ee.Name == Name);
        }
    }
}

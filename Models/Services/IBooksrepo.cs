using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Services
{
    public interface IBooksrepo
    {
        public List<Books> getall();
        public void AddBook(Books b);
        public void EditBook(Books b);
        public void DelBook(int id);
        public Books FindBook(int id);
    
    }
}

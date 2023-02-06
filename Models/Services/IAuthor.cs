using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Services
{
    public interface IAuthorRepo
    {
        public List<Authors> getall();
        public void AddAuthor(Authors a);
        public void EditAuthor( Authors a);
        public void DelAuthor(int id);
        public Authors FindAuthor(int id);
        public Authors FindByName(string Name);

    }
}

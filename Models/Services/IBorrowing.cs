using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Services
{
   public interface IBorrowing
    {
         List<Borrower> GetAll();
         void AddBorrower(Borrower b);
         Borrower FindBorrower(int id);
         void EditBorrower(Borrower b);
         void DelBorrower(int id);
    }
}

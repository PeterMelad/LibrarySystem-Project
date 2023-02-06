using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class BorrowBook
    {
        [Key]
        public int id { get; set; }
        public int BookID { get; set; }         // 3mlt el line da 3l4an t3rf t4ofha fe el database w  td5l value feha
        public Books Book { get; set; }         // de 3l4an twd7 el relationship bs  (el relation one-to-one el relation one-to-one between Borrower w book)
        public int BorrowerID { get; set; }         // 3mlt el line da 3l4an t3rf t4ofha fe el database w t3rf td5l value feha
        public Borrower Borrower { get; set; }      // de 3l4an twd7 el relationship bs (el relation one-to-one between Borrower w book) 
    }
}

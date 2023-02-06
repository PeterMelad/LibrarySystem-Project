using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Borrower
    {
        [Required]
        public string Name { get; set; }
        public DateTime DateOfRecieve { get; set; }
        public DateTime DateOfBorrow { get; set; }
        public List<BorrowBook> BorrowBooks { get; set; }
        [Key]
        public int id { get; set; }
        [NotMapped]
        public int BookID { get; set; }
        [NotMapped]
        public int BookToRemove { get; set; }
    }
}

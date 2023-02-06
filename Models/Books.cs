using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Books
    {
        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }
        [DataType(DataType.Text)]
        public string Edition { get; set; }
        [Key]
        public int id { get; set; }
        [Required]
       public Authors author { get; set; }
        
        public int BookCount { get; set; }
        public IEnumerable<BorrowBook> BorrowBooks { get; set; }

    }
}

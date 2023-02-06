using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Authors
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        public IEnumerable<Books> book { get; set; }
        [DataType(DataType.Text)]
        public string Describtion { get; set; }
        [Key]
        public int id { get; set; }
    }
}

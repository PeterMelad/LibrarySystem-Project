using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ApplicationUser:IdentityUser       // ana 3mlt el class da 3l4an adeef columns l table el user fe el database
    {
        [Required,MaxLength(10)]
        public string FirstName { get; set; }
        [Required, MaxLength(10)]
        public string LastName { get; set; }
        public byte[] ProfilePic { get; set; }      //de kda h7ot feha el pictures 3l4a t stored in database
    }
}

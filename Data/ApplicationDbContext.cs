using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // builder.Entity<IdentityUser>().ToTable("Users");              // kda ana 8yrt asm el table bta3 el user fe el database l "users"
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");    // 8yrt asm el table 
        }

        public DbSet<Books> books { get; set; }
        public DbSet<Authors> auhors { get; set; }
        public  DbSet<Borrower> Borrowers { get; set; }
        public DbSet<BorrowBook> BorrowBooks { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SenthilTask.Models
{
    public class ApplicationUserClass:DbContext
    {
        public ApplicationUserClass(DbContextOptions<ApplicationUserClass> options):base(options)
        {

        }

        public DbSet<UserClass> UserReg { get; set; }
        public DbSet<Product> tbl_Product { get; set; }
        //public DbSet<LoginClass> UserReg { get; set; }

        



    }
}

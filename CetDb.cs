using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace HW3
{
   
        public class CetDb : DbContext
        {
            string connectionString = "Server=.;Database=CetDb;Trusted_Connection=True;";
            public DbSet<Student> Students { get; set; }
            public DbSet<Course> Courses { get; set; }
            public CetDb() : base()
            {

            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }



    
}

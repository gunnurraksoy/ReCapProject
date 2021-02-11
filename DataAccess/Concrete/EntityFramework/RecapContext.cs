using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class RecapContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {//projem hangi veritabanı ile ilişili?
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=recap;Trusted_Connection=true");
        }


        //Classlarımızı veri tabanındaki tablolar ile eşleştirdik.  
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors{ get; set; }
        public DbSet<Brand> Brands { get; set; }
    }

   
}

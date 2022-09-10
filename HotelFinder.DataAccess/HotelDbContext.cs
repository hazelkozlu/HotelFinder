using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.DataAccess
{
    public class HotelDbContext : DbContext
    {
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Hotel>().HasData(new Hotel
        //    {
        //        Id = 1,
        //        Name = "Çınar Hotel",
        //        City = "New York",
              

        //    });
        //    modelBuilder.Entity<Hotel>().HasData(new Hotel
        //    {
        //        Id = 2,
        //        Name = "Assosia Hotel",
        //        City = "New York",


        //    });
        //}
        //HotelFinder.DataAccess a entityframeworkcore sqlserver ve tools paketlerini indirdik manage nugetten
        //migration lar için entityframeworkcore.tools u indirdik
        //migration için dataaccess projesinin pmconsole da seçili olması ve set as startuo project denmesi gerekiyor.
        //migration ekle add-migration InitialCreate update-database 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //"Server=DESKTOP-2ID4KL6\SQLEXPRESS;Database=PersonnelDB;Integrated Security=true"
            optionsBuilder.UseSqlServer("Server=DESKTOP-2ID4KL6;Database=HotelDB;Integrated Security=true");

        }
        //bu Entities class library sindeki classlar benim sql imdeki tablolar
        public DbSet<Hotel> Hotels { get; set; }
        //budemek oluyorki bussines katmanında HotelDbContext i new leyince Hotels diye bir property gelecek
        //oda dbset türünden olduğu için dbset teki add, addrance,update gibi methotlara uşamış olacağım
    }
}

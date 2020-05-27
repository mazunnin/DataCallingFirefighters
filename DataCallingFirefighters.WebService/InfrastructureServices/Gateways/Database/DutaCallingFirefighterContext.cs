using Microsoft.EntityFrameworkCore;
using DataCallingFirefighters.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCallingFirefighters.InfrastructureServices.Gateways.Database
{
    public class DutaCallingFirefighterContext : DbContext
    {
        public DbSet<DataCallingFirefighter> DataCallingFirefighters { get; set; }


        public DutaCallingFirefighterContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataCallingFirefighter>().HasData(
                new DataCallingFirefighter()
                {
                    Id = 1,
                    District = "Северный Административный округ", 
                    Year = "2015",
                    Month = "Январь",
                    NumberOfCalls = "408"
                }
             );
        }
    }
}

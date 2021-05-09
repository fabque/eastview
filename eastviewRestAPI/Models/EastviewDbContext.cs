using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EastviewRestAPI.Models
{
    public class EastviewDbContext : DbContext
    {
        public EastviewDbContext(DbContextOptions options)
                    : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Citizen>()
                .HasData(
                    new Citizen
                    {        
                        Id = 1,
                        FirstName = "John",
                        LastName = "Doe",
                        Address = "1512 Doe St",
                        Job = "Constructor"
                    },
                   new Citizen
                   {
                       Id = 2,
                       FirstName = "Jane",
                       LastName = "Doe",
                       Address = "1512 Doe St",
                       Job = "Actress"
                   },
                   new Citizen
                   {
                       Id = 3,
                       FirstName = "Steve",
                       LastName = "Smith",
                       Address = "302 Peachtree St",
                       Job = "Student"
                   }
                );
            modelBuilder.Entity<CitizenTask>()
               .HasData(
                   new CitizenTask {
                       Id = 1,
                       Day = DayOfWeek.Monday,
                       Description = "Finish house kitchen",
                       CitizenId = 1
                   },
                   new CitizenTask
                   {
                       Id = 2,
                       Day = DayOfWeek.Monday,
                       Description = "Film TV Serie chapter",
                       CitizenId = 2
                   },
                   new CitizenTask
                   {
                       Id = 3,
                       Day = DayOfWeek.Monday,
                       Description = "Assist to English class",
                       CitizenId = 3
                   }
                   );
        }
        public DbSet<Citizen> Citizens { get; set; }

        public DbSet<CitizenTask> Tasks { get; set; }
    }
}

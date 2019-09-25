using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTrackers.BackService.Models;

namespace TripTrackers.BackService.Data
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options) : base(options) { }
        public TripContext() { }
        public DbSet<Trip> Trips { get; set; }

        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider
                .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope
                    .ServiceProvider.GetService<TripContext>();

                context.Database.EnsureCreated(); //make sure the database is created
                if (context.Trips.Any())
                {
                    return;
                }

                context.Trips.AddRange(new Trip[]
                   {
                   new Trip{
                Id = 1,
                Name= "Hawaii",
                StartDate = new DateTime(2020,3,1),
                EndDate = new DateTime(2020,3,15)
               },
            new Trip{
                Id= 2,
                Name="Morocco",
                StartDate=new DateTime(2020,8,15),
                EndDate= new DateTime(2020,9,5)
               },
            new Trip{
                Id= 3,
                Name="Greece",
                StartDate = new DateTime(2021,6,15),
                EndDate = new DateTime(2021,6,25)
              }
                }
                    );
                context.SaveChanges();
            }
        }
    }


}

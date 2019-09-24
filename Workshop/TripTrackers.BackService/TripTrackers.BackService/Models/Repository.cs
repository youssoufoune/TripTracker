using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripTrackers.BackService.Models
{
    public class Repository
    {
        private List<Trip> MyTrips = new List<Trip> {
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
        };
        public List<Trip> GetAllTrips() {
            return MyTrips;
        }
        public Trip GetTrip(int id) {
            return MyTrips.FirstOrDefault(t => t.Id == id);
        }
        public void AddTrip(Trip newTrip) {
            MyTrips.Add(newTrip);
        }

        public void Update(Trip tripToUpdate) {
            MyTrips.Remove(MyTrips.FirstOrDefault(t => t.Id == tripToUpdate.Id));
            AddTrip(tripToUpdate);
        }
        public void RemoveTrip(int id)
        {
            MyTrips.Remove(MyTrips.FirstOrDefault(t => t.Id == id));
        }
    }
}

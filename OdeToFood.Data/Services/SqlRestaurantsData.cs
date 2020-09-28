using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;
        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public void Add(Restaurant restaurant)
        {
            //we add the data to be saved as a parameter
            db.Restaurants.Add(restaurant);
            //Here we commit the changes 
            db.SaveChanges();
        }

        

        public Restaurant Get(int id)
        {
            //Given a Restaurant R, Lets make sure the ID of that R matches or else return null
            return db.Restaurants.FirstOrDefault(r => r.Id == id);

        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in db.Restaurants
                   orderby r.Name
                   select r;
        }

        public void Update(Restaurant restaurant)
        {
            //Right way
            var entry = db.Entry(restaurant);
            //we make sure that the users override one to each other using this by pulling the info at the time we're adding it

            entry.State = EntityState.Modified;

            //option 2
            //var r = Get(restaurant.Id);
            //r.Name = "";

            //save changes
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
        }
    }
}

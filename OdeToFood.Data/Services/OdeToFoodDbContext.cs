using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    //Our own Connection to the Database from EF 
    public class OdeToFoodDbContext : DbContext
    {
        //Table that has Restaurant class data
        //We give instructions to the EF on the tables we need
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}

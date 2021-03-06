using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRaterMVC.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Rating { get; set; }

    }//end of class Restaurant

    public class RestaurantDbContext: DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

    }//end of class
}
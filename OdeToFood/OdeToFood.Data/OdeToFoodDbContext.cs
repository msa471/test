using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodContext> options)
            : base(options) => Options = options;
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbContextOptions<OdeToFoodContext> Options { get; }
    }

    public class OdeToFoodContext
    {
    }
}

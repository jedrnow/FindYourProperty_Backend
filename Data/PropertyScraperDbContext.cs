using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PropertyScraper.Models;

namespace PropertyScraper.Data
{
    public class PropertyScraperDbContext : DbContext
    {
        public PropertyScraperDbContext(DbContextOptions<PropertyScraperDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }

        public DbSet<PropertyImage> PropertyImage { get; set; }
    }
}

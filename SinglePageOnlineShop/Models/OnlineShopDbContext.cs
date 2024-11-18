using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineShop.Models.DomainModels;

namespace OnlineShop.Models
{
    public class OnlineShopDbContext:DbContext
    {
        public DbSet<Person> Person { get; set; }
        

        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext>options):base(options)
        {

            
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{


        //    base.OnModelCreating(modelBuilder);
        //}


    }
}

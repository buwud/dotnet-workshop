using dotnet_workshop_deneme.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_workshop_deneme.Data
{
    public class Context : DbContext
    {
        public Context( DbContextOptions<Context> options )
             : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}

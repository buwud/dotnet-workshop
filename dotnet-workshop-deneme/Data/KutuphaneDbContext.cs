using dotnet_workshop_deneme.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_workshop_deneme.Data
{
    public class KutuphaneDbContext : DbContext
    {
        public KutuphaneDbContext( DbContextOptions<KutuphaneDbContext> options )
             : base(options)
        {
            //yeni bir nesne oluşturulduğunda bu metot çağırılır
        }

        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }

    }
}

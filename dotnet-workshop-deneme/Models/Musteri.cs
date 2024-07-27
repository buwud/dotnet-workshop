namespace dotnet_workshop_deneme.Models
{
    public class Musteri
    {
        //müşteri için gerekli olan özellikler, veritabanında tablo oluşturulurken bu özellikler kullanılacak
        public int Id { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }

        public List<Kitap> Kitaplar { get; set; }=new List<Kitap>();
    }
}

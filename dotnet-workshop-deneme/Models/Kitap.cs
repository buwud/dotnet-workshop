namespace dotnet_workshop_deneme.Models
{
    public class Kitap
    {
        //kitap için gerekli olan özellikler, veritabanında tablo oluşturulurken bu özellikler kullanılacak
        public int Id { get; set; }
        public string Isim { get; set; }
        public string Yazar { get; set; }
        public string Yayinevi { get; set; }
        public string Icerik { get; set; }
        public string SayfaSayisi { get; set; }

    }
}
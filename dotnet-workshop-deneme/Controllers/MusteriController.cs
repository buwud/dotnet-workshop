using dotnet_workshop_deneme.Data;
using dotnet_workshop_deneme.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_workshop_deneme.Controllers
{
    [ApiController]
    //Route belirtilen kısım, controller'ın route'unun başlangıç adresini belirler
    //Bu sayede controller'a erişim sağlanabilir
    //Bu controller'a erişim sağlamak için "api/musteri" adresi kullanılmalıdır
    [Route("api/[controller]")]
    public class MusteriController : Controller
    {
        //Context sınıfından bir nesne oluşturuldu
        private readonly KutuphaneDbContext _context;

        //oluşturulan nesne constructor metot ile çağırıldı
        //bu sayede veritabanı işlemleri gerçekleştirilebilir
        //bu sınıfın içindeki metotlar veritabanı işlemlerini gerçekleştirir
        public MusteriController( KutuphaneDbContext context )
        {
            _context = context;
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult<List<Musteri>> GetAll()
        {
            return _context.Musteriler.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Musteri> GetById( int id )
        {
            var customer = _context.Musteriler.Find(id);
            if ( customer == null )
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public ActionResult<Musteri> Create( Musteri customer )
        {

            _context.Musteriler.Add(customer);
            _context.SaveChanges();

            return Ok(customer);
        }
        [HttpPatch("{id}")]
        public ActionResult<Musteri> Update( int id, Musteri customer )
        {
            if ( id != customer.Id )
            {
                return BadRequest("ID mismatch");
            }

            var existingCustomer = _context.Musteriler.Find(id);
            if ( existingCustomer == null )
            {
                return NotFound();
            }

            _context.Entry(existingCustomer).CurrentValues.SetValues(customer);
            _context.SaveChanges();

            return Ok(customer);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete( int id )
        {
            var customer = _context.Musteriler.Find(id);
            if ( customer == null )
            {
                return NotFound();
            }

            _context.Musteriler.Remove(customer);
            _context.SaveChanges();

            return NoContent();
        }
        //musterilere kitap ekleme
        [HttpPost("{id}/addbook")]
        public ActionResult<Musteri> AddBook( int id, [FromBody] int bookId )
        {
            var customer = _context.Musteriler.Find(id);
            if ( customer == null )
            {
                return NotFound();
            }

            var book = _context.Kitaplar.Find(bookId);
            if ( book == null )
            {
                return NotFound();
            }

            customer.Kitaplar.Add(book);
            _context.SaveChanges();

            return Ok(customer);
        }
        //musteriden kitap silme
        [HttpDelete("{id}/removebook")]
        public ActionResult<Musteri> RemoveBook( int id, [FromBody] int bookId )
        {
            var customer = _context.Musteriler.Find(id);
            if ( customer == null )
            {
                return NotFound();
            }

            var book = _context.Kitaplar.Find(bookId);
            if ( book == null )
            {
                return NotFound();
            }

            customer.Kitaplar.Remove(book);
            _context.SaveChanges();

            return Ok(customer);
        }

        //müşterileri kitapları ile birlikte getirme
        [HttpGet("{id}/books")]
        public ActionResult<Musteri> GetBooks( int id )
        {
            var customer = _context.Musteriler.Find(id);
            if ( customer == null )
            {
                return NotFound();
            }
            return Ok(customer.Kitaplar);
        }

    }
}

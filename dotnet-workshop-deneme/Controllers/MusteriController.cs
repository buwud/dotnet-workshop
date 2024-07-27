using dotnet_workshop_deneme.Data;
using dotnet_workshop_deneme.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_workshop_deneme.Controllers
{
    [ApiController]
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
    }
}

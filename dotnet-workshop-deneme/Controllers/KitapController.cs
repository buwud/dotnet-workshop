using dotnet_workshop_deneme.Data;
using dotnet_workshop_deneme.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_workshop_deneme.Controllers
{
    public class KitapController : Controller
    {
        private readonly KutuphaneDbContext _context;
        public KitapController( KutuphaneDbContext context )
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/kitap/getall")]
        public ActionResult<List<Kitap>> GetAll()
        {
            return _context.Kitaplar.ToList();
        }
        [HttpGet]
        [Route("api/kitap/{id}")]
        public ActionResult<Kitap> GetById( int id )
        {
            var book = _context.Kitaplar.Find(id);
            if ( book == null )
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost]
        [Route("api/kitap")]
        public ActionResult<Kitap> Create( Kitap kitap )
        {
            _context.Kitaplar.Add(kitap);
            _context.SaveChanges();

            return Ok(kitap);
        }
        [HttpPatch]
        [Route("api/kitap/{id}")]
        public ActionResult<Kitap> Update( int id, Kitap kitap )
        {
            if ( id != kitap.Id )
            {
                return BadRequest("ID mismatch");
            }

            var existingBook = _context.Kitaplar.Find(id);
            if ( existingBook == null )
            {
                return NotFound();
            }

            _context.Entry(existingBook).CurrentValues.SetValues(kitap);
            _context.SaveChanges();

            return Ok(existingBook);
        }
    }
}

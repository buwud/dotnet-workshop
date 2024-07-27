using dotnet_workshop_deneme.Data;
using dotnet_workshop_deneme.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_workshop_deneme.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly Context _context;

        public CustomerController( Context context )
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Customer>> GetAll()
        {
            return _context.Customers.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetById( int id )
        {
            var customer = _context.Customers.Find(id);
            if ( customer == null )
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public ActionResult<Customer> Create( Customer customer )
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return Ok(customer);
        }
        [HttpPut("{id}")]
        public ActionResult<Customer> Update( int id, Customer customer )
        {
            if ( id != customer.Id )
            {
                return BadRequest("ID mismatch");
            }

            var existingCustomer = _context.Customers.Find(id);
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
            var customer = _context.Customers.Find(id);
            if ( customer == null )
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

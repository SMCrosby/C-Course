using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesWebApiEF.Data;
using SalesWebApiEF.Models;

namespace SalesWebApiEF.Controllers
{                                               //Route = points to which controller you want to use
    [Route("api/[controller]")]                 //api/[controller] removes the word controller from whatever follows api
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly SalesContext _context;

        public CustomersController(SalesContext context) {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer() {
            return await _context.Customer.ToListAsync();                   //Getting list of all the customers
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]   //Says one more piece of data after api --path variable"{id}" must be used in the parameter of the method
        public async Task<ActionResult<Customer>> GetCustomer(int id) {     //--id is used in the parameter()
           
            var customer = await _context.Customer.FindAsync(id);                  //Find customer by Id
            if (customer == null) {                                                 //Or return null
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]   
        public async Task<IActionResult> PutCustomer(int id, Customer customer) {
            if (id != customer.Id) {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();                      //Updating data
            }
            catch (DbUpdateConcurrencyException) {
                if (!CustomerExists(id)) {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        //POST is used when adding or inserting data/updates
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer) {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id) {
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null) {
                return NotFound();
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        private bool CustomerExists(int id) {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}

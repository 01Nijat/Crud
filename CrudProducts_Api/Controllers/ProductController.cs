using CrudProducts_Api.Data;
using CrudProducts_Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudProducts_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _context.Product.ToList();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product GetOne(int id)
        {
            var product = _context.Product.FirstOrDefault(p => p.Id == id);
            return product;
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            try
            {
                _context.Product.Add(product);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            if (product.Id == id)
            {
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
                return BadRequest();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var producto = _context.Product.FirstOrDefault(p => p.Id == id);
            if(producto != null)
            {
                _context.Product.Remove(producto);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}

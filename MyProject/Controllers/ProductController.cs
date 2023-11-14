using Microsoft.AspNetCore.Mvc;
using MyProject.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase {

        private readonly DataContext _dataContext;
        public ProductController(DataContext context)
        {
            _dataContext = context;
        }




        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _dataContext.products;

        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var p = _dataContext.products.Find(s => s.Id == id);
            if (p == null)
                return NotFound();
            else
                return p;
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody] string value)
        {
            var product = _dataContext.products.Find(s => s.Id == id);
            if (product == null)
                return NotFound();
            else
                product.Name = value;
            return product;
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            var product = _dataContext.products.Find(s => s.Id == id);
            if (product == null)
                return NotFound();
            else
                _dataContext.products.Remove(product);
            return product;

        }
    }
}


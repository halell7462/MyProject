using Microsoft.AspNetCore.Mvc;

using MyProject.Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class customerController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public customerController(DataContext context)
        {
            _dataContext = context;   
        }

        // GET: api/<customerController>
        [HttpGet]
        public  IEnumerable <Customer> Get()
        {
            
            return _dataContext.customers;
        }

        // GET api/<customerController>/5
        [HttpGet("{id}")]
        public ActionResult <Customer> Get(int id)
        {
          var c= _dataContext.customers.Find(s=>s.Id==id) ;
            if (c == null)
                return NotFound();
            else
                return c;
        }

        // POST api/<customerController>
        [HttpPost]
        public void Post([FromBody]Customer value)
        {
            _dataContext.customers.Add(new Customer { Id=1,Name=value.Name});

        }

        // PUT api/<customerController>/5
        [HttpPut("{id}")]
        public ActionResult<Customer> Put(int id, [FromBody] string value)
        {
            var customer = _dataContext.customers.Find(s => s.Id == id);
            if (customer == null)
                return NotFound();
            else
                customer.Name = value;
            return customer;
        }

        // DELETE api/<customerController>/5
        [HttpDelete("{id}")]
        public ActionResult<Customer>  Delete(int id)
        {
            var customer = _dataContext.customers.Find(s => s.Id == id);
            if (customer == null)
                return NotFound();
            else
                _dataContext.customers.Remove(customer);
            return customer;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MyProject.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
            private readonly DataContext _dataContext;
            public CityController(DataContext context)
            {
                _dataContext = context;
            }
            // GET: api/<CityController>
            [HttpGet]
            public IEnumerable<City> Get()
            {
                return _dataContext.city;
            }

            // GET api/<CityController>/5
            [HttpGet("{id}")]
            public ActionResult<City> Get(int cnt)
            {
                var c = _dataContext.city.Find(s => s.cnt == cnt);
                if (c == null)
                    return NotFound();
                else
                    return c;
            }

            // POST api/<CityController>
            [HttpPost]
            public void Post([FromBody] City value)
            {
                _dataContext.city.Add(new City { cnt = value.cnt, Name = value.Name });
            }

            // PUT api/<CityController>/5
            [HttpPut("{id}")]
            public ActionResult Put(int cnt, [FromBody] String value)
            {
                var c = _dataContext.city.Find(s => s.Name == value);
                if (c == null)
                    return NotFound();
                else
                    c.cnt = cnt;
                return Ok();
            }

            // DELETE api/<CityController>/5
            [HttpDelete("{id}")]
            public ActionResult<City> Delete(String value)
            {
                var c = _dataContext.city.Find(s => s.Name == value);
                if (c == null)
                    return NotFound();
                else
                    _dataContext.city.Remove(c);
                return Ok();
            }
        }
    }
}

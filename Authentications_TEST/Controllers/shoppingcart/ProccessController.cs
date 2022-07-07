using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Authentications_TEST.Controllers.shoppingcart
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProccessController : ControllerBase
    {
        // GET: api/<ProccessController>
      
        // GET api/<ProccessController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProccessController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProccessController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProccessController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

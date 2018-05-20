using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Produces("application/json", "application/xml")]
    
    [Route("api/Values")]
    public class ValuesController : Controller
    {
        // GET: api/Values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, string query)
        {
            return Ok(new Value { Id = id, Text = "VAlue" + id });
        }

        // POST: api/Values
        [HttpPost]
        public IActionResult Post([FromBody]Value value)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //save the value to the database
            return CreatedAtAction("Get", new { value.Id }, value );
        }
        
        // PUT: api/Values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public class Value
        {
            public int Id { get; set; }
            [MinLength(3)]
            public string Text { get; set; }
        }
    }
}

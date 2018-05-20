using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
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
        [HttpGet("{id:int}")]
        public string Get(int id, string query)
        {
            return $"value {id}, query = {query}";
        }
        
        // POST: api/Values
        [HttpPost]
        public void Post([FromBody]Value value)
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidOperationException("Invalid");
            }
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

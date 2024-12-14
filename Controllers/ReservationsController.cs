using Microsoft.AspNetCore.Mvc;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace net2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private static List<Event> _events = new List<Event>
        {
            new Event { Id = 1, Title = "Event 1", Start = new DateOnly(2024, 12, 1) },


new Event { Id = 2, Title = "Event 2", Start = new DateOnly(2024, 12, 10) },
            new Event { Id = 3, Title = "Event 3", Start = new DateOnly(2024, 12, 20) }
        };

        public EventsController()
        {

        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _events;
        }

        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Event newEvent)
        {
            _events.Add(new Event { Id = 2, Title = newEvent.Title });
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event updatedEvent)
        {
            var existingEvent = _events.FirstOrDefault(e => e.Id == id);
            if (existingEvent != null)
            {
                existingEvent.Title = updatedEvent.Title ?? existingEvent.Title;
                existingEvent.Start = updatedEvent.Start != default ? updatedEvent.Start : existingEvent.Start;
                existingEvent.End = updatedEvent.End != default ? updatedEvent.End : existingEvent.End;
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var existingEvent = _events.FirstOrDefault(e => e.Id == id);
            if (existingEvent != null)
            {
                _events.Remove(existingEvent);
            }

        }
    }
}
     
    



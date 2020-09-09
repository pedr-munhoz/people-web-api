using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using people_web_api.Models;
using people_web_api.Services;

namespace people_web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly PersonService _service;

        public PeopleController(PersonService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Person>> Get() =>
            _service.Get();

        [HttpGet("{id:length(24)}", Name = "GetById")]
        public ActionResult<Person> Get(string id)
        {
            var person = _service.Get(id);

            if (person == null)
                return NotFound();

            return person;
        }


        [HttpPost]
        public ActionResult<Person> Create(Person item)
        {
            _service.Create(item);

            return CreatedAtRoute("GetById", new { id = item.Id.ToString() }, item);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, Person item)
        {
            var person = _service.Get(id);

            if (person == null)
                return NotFound();

            _service.Update(id, item);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            var person = _service.Get(id);

            if (person == null)
                return NotFound();

            _service.Remove(id);

            return NoContent();
        }
    }
}
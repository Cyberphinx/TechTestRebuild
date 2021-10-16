using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repositories;
using API.Repositories.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/people")]
    [ApiController]    
    public class PeopleController : ControllerBase
    {
        public PeopleController(IPersonRepository personRepository)
        {
            this.PersonRepository = personRepository;
        }

        public IPersonRepository PersonRepository { get; }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            // TODO: Step 1
            //
            // Implement a JSON endpoint that returns the full list
            // of people from the PeopleRepository. If there are zero
            // people returned from PeopleRepository then an empty
            // JSON array should be returned.

            var persons = this.PersonRepository.GetAll();

            return this.Ok(persons);
        }

        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            // TODO: Step 2
            //
            // Implement a JSON endpoint that returns a single person
            // from the PeopleRepository based on the id parameter.
            // If null is returned from the PeopleRepository with
            // the supplied id then a NotFound should be returned.

            var person = this.PersonRepository.Get(id);

            if (person == null) return NotFound();

            return person;
        }

        [HttpPut("{id}")]
        public ActionResult<Person> Update(int id, Person person)
        {
            // TODO: Step 3
            //
            // Implement an endpoint that receives a JSON object to
            // update a person using the PeopleRepository based on
            // the id parameter. Once the person has been successfully
            // updated, the person should be returned from the endpoint.
            // If null is returned from the PeopleRepository then a
            // NotFound should be returned.

            try
            {
                if (id != person.Id)
                    return BadRequest("Employee ID mismatch");

                var personToUpdate = this.PersonRepository.Get(id);

                if (person == null)
                    return NotFound();
                
                return this.PersonRepository.Update(person);
            }

            catch (Exception)
            {
                return StatusCode(500, "Error updating data");
            }

        }
    }
}
using EmployeeManagement.Data;
using EmployeeManagement.Models.Entitties;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Net;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PersonController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        // ------------------------------------------------------------------------------

        // ASP.NET Core automatically passes the DbContext here

        // ------------------------------------------------------------------------------
        public PersonController(EmployeeDbContext context)
        {
            _context = context;
        }

        //GET: api/allpersons
        [HttpGet]
        public IActionResult GetPersons()
        {
            var allpersons = _context.Persons.ToList();
            return Ok(allpersons);
        }

        //GET: api/persons/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetPersonById(Guid id)
        {
            var person = _context.Persons.Find(id);
            if(person == null)
            {
                return NotFound($"Person with ID {id} not found. ");
            }
            return Ok(person);
        }

        //POST: api/persons
        [HttpPost]
        public IActionResult AddPerson (Person addPerson)
        {
            var person = new Person()
            {
                Name = addPerson.Name,
                Description = addPerson.Description,
                Title = addPerson.Title,
                Address = addPerson.Address,
                City = addPerson.City,
                Region = addPerson.Region,
                PostalCode = addPerson.PostalCode,
                Country = addPerson.Country,
                Phone = addPerson.Phone,
                Fax = addPerson.Fax,
                HomePage = addPerson.HomePage,
                Extension = addPerson.Extension,
                Note = addPerson.Note
            };
            _context.Persons.Add(person);
            _context.SaveChanges();

            return Ok(person);
            
        }

        //PUT: api/persons/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdatePerson (Guid id, Person updatePerson)
        {
            var person = _context.Persons.Find(id);
            if( person == null )
            {
                return NotFound($"Person with ID {id} not found. ");
            }

            person.Name = updatePerson.Name;
            person.Description = updatePerson.Description;
            person.Title = updatePerson.Title;
            person.Address = updatePerson.Address;
            person.City = updatePerson.City;
            person.Region = updatePerson.Region;
            person.PostalCode = updatePerson.PostalCode;
            person.Country = updatePerson.Country;
            person.Phone = updatePerson.Phone;
            person.Fax = updatePerson.Fax;
            person.HomePage = updatePerson.HomePage;
            person.Extension = updatePerson.Extension;
            person.Note = updatePerson.Note;

            _context.SaveChanges(true);
            return Ok(person);
        }

        //DELETE: api/persons/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeletePerson (Guid id)
        {
            var person = _context.Persons.Find(id);
            if ( person == null )
            {
                return NotFound($"Person with ID {id} not found. ");
            }

            _context.Persons.Remove(person);
            _context.SaveChanges();

            return Ok(person);
        }
    }
}

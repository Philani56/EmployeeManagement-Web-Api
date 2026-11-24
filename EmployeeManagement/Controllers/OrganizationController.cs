using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Data;
using EmployeeManagement.Models.Entitties;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrganizationController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        // ------------------------------------------------------------------------------

        // ASP.NET Core automatically passes the DbContext here

        // ------------------------------------------------------------------------------

        public OrganizationController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: all organizations
        [HttpGet]
        public IActionResult GetOrganizations()
        {
            var allOrganizations = _context.Organizations.ToList();
            return Ok(allOrganizations);
        }

        // GET: api/organizations/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetOrganizationById(Guid id)
        {
            var organization = _context.Organizations.Find(id);
            if (organization == null)
            {
                return NotFound($"Organization with ID {id} not found. ");
            }

            return Ok(organization);

        }

        // POST: api/organizations
        [HttpPost]
        public IActionResult AddOrganization(Organization addorganization)
        {
            var organization = new Organization()
            {
                Name = addorganization.Name,
                County = addorganization.County,
            };


            _context.Organizations.Add(organization);
            _context.SaveChanges();

            return Ok(organization);

        }

        // PUT: api/organizations/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateOrganization(Guid id, Organization updateorganization)
        {
            var organization = _context.Organizations.Find(id);
            if (organization == null)
            {
                return NotFound($"Organization with ID {id} not found. ");
            }

            organization.Name = updateorganization.Name;
            organization.County = updateorganization.County;

            _context.SaveChanges();
            return Ok(organization);

        }

        // DELETE: api/organizations/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteOrganization(Guid id)
        {
            var organization = _context.Organizations.Find(id);
            if (organization == null)
            {
                return NotFound($"Organization with ID {id} not found. ");
            }

            _context.Organizations.Remove(organization);
            _context.SaveChanges();

            return Ok(organization);
        }
    }
}

using EmployeeManagement.Data;
using EmployeeManagement.Models.Entitties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmployeeManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ClientController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        // ------------------------------------------------------------------------------

        // ASP.NET Core automatically passes the DbContext here

        // ------------------------------------------------------------------------------
        public ClientController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: api/clients 
        [HttpGet]
        public IActionResult GetClient()
        {
            var allclients = _context.Clients.ToList();
            return Ok(allclients);
        }

        // GET: api/clients/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetClientById (Guid id)
        {
            var clients = _context.Clients.Find(id);
            if(clients == null)
            {
                return NotFound($"Client with ID {id} not found. ");
            }

            return Ok(clients);
        }

        // POST: api/clients
        [HttpPost]
        public IActionResult AddClient(Client addclient)
        {
            var clientsEntity = new Client()
            {
                Client_Name = addclient.Client_Name,
                Birth = addclient.Birth,
                Phone_Number = addclient.Phone_Number,
                Age = addclient.Age,
            };

            _context.Clients.Add(clientsEntity);
            _context.SaveChanges();

            return Ok(clientsEntity);
        }

        // PUT: api/employees/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateClient(Guid id, Client updateclient)
        {
            var client = _context.Clients.Find(id);
            if(client == null)
            {
                return NotFound($"Client with ID {id} not found. ");
            }

            client.Client_Name = updateclient.Client_Name;
            client.Birth = updateclient.Birth;
            client.Phone_Number = updateclient.Phone_Number;
            client.Age = updateclient.Age;

            _context.SaveChanges();
            return Ok(client);
        }

        // DELETE: api/clients/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteClient(Guid id)
        {
            var client = _context.Clients.Find(id);
            if(client == null)
            {
                return NotFound($"Client with ID {id} not found. ");
            }
            
            _context.Clients.Remove(client);
            _context.SaveChanges();
            return Ok(client);
        }
    }
}

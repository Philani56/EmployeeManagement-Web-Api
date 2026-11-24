// Controllers: Contains API controllers
// EmployeesController.cs

using EmployeeManagement.Data;
using EmployeeManagement.Models.Entitties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmployeeManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class EmployeesController : ControllerBase
    {

        private readonly EmployeeDbContext _context;

        // ------------------------------------------------------------------------------

        // ASP.NET Core automatically passes the DbContext here

        // ------------------------------------------------------------------------------
        public EmployeesController(EmployeeDbContext context)
        {
            _context = context;
        }

        // ------------------------------------------------------------------------------

        // 1. GET – Get All Employees & Get by ID
        // These two methods handle the retrieval of employee data.

        // > The first method [HttpGet] returns a full list of employees with an HTTP 200 OK response.
        // > The second method [HttpGet("{id}")] retrieves a specific employee by ID.

        // ------------------------------------------------------------------------------

        // GET: api/employees
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = _context.Employees.ToList(); // declare variable of all employees
            return Ok(allEmployees);

        }

        // GET: api/employees/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = _context.Employees.Find(id); // declare variable of an employee

            // if statement
            // if there is no employee return a message which says "Employee with this ID not found."
            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found. ");
            }

            return Ok(employee);
        }

        // ------------------------------------------------------------------------------

        // 2. POST – Add a New Employee
        // This method handles employee creation.

        // > The [HttpPost] method accepts an Employee object from the request body.
        // > It adds the employee to the database.

        // ------------------------------------------------------------------------------

        // POST: api/employees
        [HttpPost]
        public IActionResult AddEmployee(Employee addEmployee)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployee.Name,
                Email = addEmployee.Email,
                Phone = addEmployee.Phone,
                Salary = addEmployee.Salary,
            };

            _context.Employees.Add(employeeEntity);
            _context.SaveChanges();

            return Ok(employeeEntity);
        }

        // ------------------------------------------------------------------------------

        // 3. PUT – Update an Existing Employee
        // This method updates the details of an existing employee

        // > The [HttpPut("{id}")] method checks if an employee with the given ID exists.
        // > It updates the employee’s name, department, phone, and salary.

        // ------------------------------------------------------------------------------

        // PUT: api/employees/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, Employee updateEmployee)
        {
            var employee = _context.Employees.Find(id);
            if(employee == null)
            {
                return NotFound($"Employee with ID {id} not found. ");
            }

            employee.Name = updateEmployee.Name;
            employee.Email = updateEmployee.Email;
            employee.Phone = updateEmployee.Phone;
            employee.Salary = updateEmployee.Salary;

            _context.SaveChanges(); // save to the database

            return Ok(employee);
        }

        // ------------------------------------------------------------------------------

        // 4. DELETE – Remove an Employee
        // This method deletes an employee based on the provided ID.

        // > The [HttpDelete("{id}")] method searches for the employee.
        // > If the employee exists, it removes them from the list.

        // DELETE: api/employees/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _context.Employees.Find(id);
            if(employee == null)
            {
                return NotFound($"Employee with ID {id} not found. ");
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return Ok(employee);
        }
    }
}

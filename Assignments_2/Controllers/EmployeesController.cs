using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignments_2.Data;
using Assignments_2.Models;

namespace Assignments_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public EmployeesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetEmployees()
        {
            var employees = await _context.Employees.Include(e => e.Department).ToListAsync();
            return Ok(employees);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employees>> GetEmployees(int id)
        {            
            var employees = await _context.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == id);
            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployees(int id, Employees employees)
        {
            var existingEmployee =  _context.Employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            var department = _context.Departments.FirstOrDefault(d => d.Id == employees.DepartmentId);
            if (department == null)
            {
                return NotFound("Department not found.");
            }
            existingEmployee.Name = employees.Name;
            existingEmployee.Age = employees.Age;
            existingEmployee.DepartmentId = employees.DepartmentId;
            existingEmployee.Department = department;
            existingEmployee.Salary = employees.Salary;
            await _context.SaveChangesAsync();
            return Ok(existingEmployee);
        }

        // POST: api/Employees
         [HttpPost]
        public async Task<ActionResult<Employees>> PostEmployees(Employees employees)
        {
            var department = _context.Departments.FirstOrDefault(d => d.Id == employees.DepartmentId);
            if (department == null)
            {
                return NotFound("Department not found.");
            }
            employees.Department= department;
            _context.Employees.Add(employees);
            await _context.SaveChangesAsync();

            return Ok(employees);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployees([FromRoute]int id)
        {
            var employees = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employees == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employees);
            await _context.SaveChangesAsync();
            return Ok(employees);
        }
    }
}

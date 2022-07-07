using Authentications_TEST.Connections;
using Authentications_TEST.Models;
using Authentications_TEST.services.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Authentications_TEST.Controllers
{
   
    [ApiController]
    [Route("[controller]")]

    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DBConnection _context;
        public EmployeesController(DBConnection context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        // GET: api/<EmployeesController>
        //[Authorize(Policy = "RequireCustomer")]
        [HttpGet]
        public ActionResult<IEnumerable<Employees>> Get()
        {
            IEnumerable<Employees> emp = _context.employees.ToList()
                .OrderBy(x => x.FirstName);

            if (emp == null)
                return BadRequest("no record found");
            return emp.ToList();
        }

       // [Authorize]
        [Authorize(Policy = "RequireCustomer")]
        [HttpGet("unit/{cn}")]        
        public ActionResult<IEnumerable<Employees>> GetpopularData(int cn)
        {
            var data = _unitOfWork.Employees.GetEmployees(cn);
            return Ok(data);
        }

        // GET api/<EmployeesController>/5  
        //[Authorize]
        [Authorize(Policy = "RequireAdmin")]
        [HttpGet("{id}")]
        public ActionResult<Employees> GetById(int id)
        {
            Employees emp = _context.employees.FirstOrDefault(x => x.EmplyeeId == id);
            if (emp == null)
                return BadRequest("no record found");
            return emp;
            
        }

        // POST api/<EmployeesController>
        [HttpPost("Insert")]
        public void Post(Employees employees)
        {
            _context.employees.Add(employees);
            _context.SaveChanges();
        }

        //PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public ActionResult<Employees> Put(Employees employee, int id)
        {
            Employees emp = _context.employees.FirstOrDefault(x => x.EmplyeeId == id);
            if (emp == null)
                return BadRequest("no record found");
            else
            {
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;

                var entry = _context.Entry(emp);
                entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            return emp;           

        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public ActionResult<Employees> Delete(int id)
        {
            Employees emp = _context.employees.FirstOrDefault(x => x.EmplyeeId == id);
            if (emp == null)
                return BadRequest("no record found");
            else
            {
                _context.employees.Remove(emp);
                _context.SaveChanges();
            }
            return emp;

        }
    }
}

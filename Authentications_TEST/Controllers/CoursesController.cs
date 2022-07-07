using Authentications_TEST.Connections;
using Authentications_TEST.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentications_TEST.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly DBConnection _context;
        public CoursesController(DBConnection conn)
        {
            _context = conn;
        }
        [HttpGet]
        public IEnumerable<Courses> getAll()
        {
            IEnumerable<Courses> crs = _context.courses.ToList()
                .OrderBy(x => x.CoursesName);
            return crs.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Courses> GetById(int id)
        {
            Courses crs = _context.courses.FirstOrDefault(x => x.CoursesId == id);
            if (crs == null)
                return BadRequest("no record found");
            return crs;

        }

        // POST api/<EmployeesController>
        [HttpPost("Insert")]
        public void Post(Courses courses)
        {
            Courses crs = new Courses
            {
                CoursesName = courses.CoursesName
            };
            _context.courses.Add(crs);
            _context.SaveChanges();
        }

        //PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public ActionResult<Courses> Put(Courses courses, int id)
        {
            Courses crs = _context.courses.FirstOrDefault(x => x.CoursesId == id);
            if (crs == null)
                return BadRequest("no record found");
            else
            {
                crs.CoursesName = courses.CoursesName;

                // std.Courses = students.Courses;

                var entry = _context.Entry(crs);
                entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            return crs;

        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public ActionResult<Courses> Delete(int id)
        {
            Courses crs = _context.courses.FirstOrDefault(x => x.CoursesId == id);
            if (crs == null)
                return BadRequest("no record found");
            else
            {
                _context.courses.Remove(crs);
                _context.SaveChanges();
            }
            return crs;

        }
    }
}

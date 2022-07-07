using Authentications_TEST.Connections;
using Authentications_TEST.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Authentications_TEST.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly DBConnection _context;
        private string _imageToken;
        private IHostingEnvironment _env;
        public StudentsController(DBConnection conn, IHostingEnvironment env)
        {
            _context = conn;
            _imageToken =  Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            _env = env;
        }

        public IEnumerable<Students> getAll()
        {
            IEnumerable<Students> std = _context.students
                .Include("Courses")
                .Include("Addresses")
                .Include("enrollment")
                .ToList()
                .OrderBy(x => x.FirstName);
                 
           
            return std;

        }

        [HttpGet("{id}")]
        public ActionResult<Students> GetById(int id)
        {
            Students std = _context.students
                .Include("Courses")
                .Include("Addresses")
                .Include("enrollment")
                .FirstOrDefault(x => x.studentsId == id);

            if (std == null)
                return BadRequest("no record found");
            return std;

        }
        //[Authorize]
        // POST api/<EmployeesController>
        [HttpPost("Insert")]
        public  ActionResult Post( [FromBody]Students students)// IFormFile file)
        {
            //var formFileImageName = Guid.NewGuid() + "__" + students.FirstName + file.FileName;
            //var dir = _env.ContentRootPath;
            //if (Directory.Exists(dir))
            //{
            //    using (var fileStream = new FileStream(Path.Combine(dir + "\\data\\images\\" + formFileImageName), FileMode.Create, FileAccess.Write))
            //    {
            //        file.CopyTo(fileStream);
            //    }
            //}

            Students s = students;
           
            IEnumerable<Courses> crs = students.Courses.ToList();
            IEnumerable<Address> adrs = students.Addresses.ToList();
            


            foreach (var c in crs)
            {
                s.Courses.Add(new Courses { CoursesName = c.CoursesName }); 
            }
            foreach (var a in adrs)
            {
                s.Addresses.Add(new Address { 
                    City = a.City, 
                    Land = a.Land,
                    Naeighberhood = a.Naeighberhood,
                    street = a.street,
                    ZipCode = Convert.ToInt32(a.ZipCode) });
            }
           //s.Profile_image = formFileImageName;



            _context.students.Add(s);
            _context.SaveChanges();
            return Ok(new { message = "successfully added"});
        }

        //PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public ActionResult<Students> Put(Students students, int id)
        {
            Students std = _context.students.FirstOrDefault(x => x.studentsId == id);
            if (std == null)
                return BadRequest("no record found");
            else
            {
                std.FirstName = students.FirstName;
                std.LastName = students.LastName;
                std.Email = students.Email;
                // std.Courses = students.Courses;

                var entry = _context.Entry(std);
                entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            return std;

        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public ActionResult<Students> Delete(int id)    
        {
            Students std = _context.students.FirstOrDefault(x => x.studentsId == id);
            if (std == null)
                return BadRequest("no record found");
            else
            {
                _context.students.Remove(std);
                _context.SaveChanges();
            }
            return std;

        }
    }
}

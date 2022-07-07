using Authentications_TEST.Connections;
using Authentications_TEST.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentications_TEST.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly DBConnection _context;
        public PdfController(DBConnection conn)
        {
            _context = conn;
        }
        [HttpGet("{id}")]
        public ActionResult<Students> getAllStudents(int id)
        {
            Students std = _context.students
                    .Include("Courses")
                    .Include("Addresses")
                    .Include("enrollment")
                    .FirstOrDefault(x => x.studentsId == id);
            return std;
        }
       
    }
}

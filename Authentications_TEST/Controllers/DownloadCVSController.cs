using Authentications_TEST.Connections;
using Authentications_TEST.Models;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Authentications_TEST.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DownloadCVSController : ControllerBase
    {
        private IHostingEnvironment _env;
        private readonly string _filepath;

        private readonly DBConnection _context;


        public DownloadCVSController(DBConnection con, IHostingEnvironment env) {
            _context = con;
            _env = env;
        }

        [HttpGet("data")]
        public ActionResult get()
        {
            return Ok(generateCSVdata());

        }
        // GET: api/<DownloadCVSController>
        [NonAction]
        public FileContentResult generateCSVdata()
        {
            //return new string[] { "value1", "value2" };
            //  string filePath = _env.ContentRootPath + "\\data\\CSV";
            var cvsPath = Path.Combine(Environment.CurrentDirectory, $"outputdata-{DateTime.Now.ToFileTime()}.csv");
            using (var stream = new StreamWriter(cvsPath))
            {
                using (var csvWriter = new CsvWriter(stream, CultureInfo.InvariantCulture))
                {
                    var data = getAllStutends();
                    //csvWriter.Configuration.AllowComments;
                    csvWriter.WriteRecords(data);


                };
            };

            return File(System.IO.File.ReadAllBytes(_env.ContentRootPath), "application/octet-stream", _filepath);
        }

        [NonAction]
        public IEnumerable<Students> getAllStutends()
        {
            IEnumerable<Students> std = _context.students.OrderByDescending(x => x.FirstName).ToList();
            return std;
        }
        


        // GET api/<DownloadCVSController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DownloadCVSController>
        [HttpPost]
        
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DownloadCVSController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DownloadCVSController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

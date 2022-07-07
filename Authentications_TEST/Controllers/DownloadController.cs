using Authentications_TEST.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Authentications_TEST.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class DownloadController : ControllerBase
    {

        private const string _sessionName = "SessionName";

        private readonly string _filepath;
        private string _token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        private IHostingEnvironment _env;

        public DownloadController(string filePath, IHostingEnvironment env)
        {
            this._filepath = filePath;
            this._env = env;
        }


        // GET: api/<DownloadController>
        [HttpGet("dwlFile")]
        public FileContentResult get()
        {
            return File(System.IO.File.ReadAllBytes(_filepath), "application/octet-stream", "testBook1.xlsx");

            // string fileapthgo = @"C:\Users\User\Desktop\google_Drive\Same Deutz-Fahr Graphics\NEW\243\9_HR363_07_0_T_Viktor\9.HR363.07.0 draft#1 - A.csv";
            //   var data = System.IO.File.ReadAllBytes(_filepath);
            //   FileContentResult res = new FileContentResult(data, "application/actet-stream")
            //   {
            //       FileDownloadName = "File.csv"
            //   };
            //   return res;

        }
        [HttpPost("uplFile")]
        public IActionResult uploadFile(IFormFile file)
        {
            // string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            var dir = _env.ContentRootPath;
            if (!Directory.Exists(dir + "\\data\\images"))
            {
                Directory.CreateDirectory(dir + "\\data\\images");
            }
            using (var filestream = new FileStream(Path.Combine(dir + "\\data\\images", _token + file.FileName), FileMode.Create, FileAccess.Write))
            {
                if (filestream == null)
                {
                    return BadRequest(new { message = "no file was send" });
                }
                else {
                    file.CopyTo(filestream);
                }


            }
            return Ok(new { message = "upload ok" });

        }

        [HttpPost("uplFiles")]
        public IActionResult uploadFiles(IEnumerable<IFormFile> files)
        {
            var i = 0;
            var dir = _env.ContentRootPath;
            if (!Directory.Exists(dir + "\\data\\images"))
            {
                Directory.CreateDirectory(dir + "\\data\\images");
            }
            foreach (var file in files)
            {
                using (var filestream = new FileStream(Path.Combine(dir + "\\data\\images", i++ + _token + file.FileName), FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(filestream);

                }
            }

            return Ok(new { message = "upload ok" });

        }
        [HttpGet("Setsession")]
        public IActionResult uploadSession()
        {
           // string cockieName = "testForm2"; //form.Keys.ToString();

            string hashedNameCookie = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

            

            HttpContext.Session.SetString(_sessionName, hashedNameCookie);

            var getsession = HttpContext.Session.GetString(_sessionName);
            return Ok(new { message = "cookies succesfully added" , getsession });
        
        }
        [HttpGet("SetsCoockie")]
        public IActionResult uploadCookie()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string value = Convert.ToBase64String(time.Concat(key).ToArray());

          //  var value2 = Convert.ToBase64CharArray(key, 80, 300, i, 4);

            // string cookieName = "testCookie01";
            string cookieName = "Main";
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(7);

            Response.Cookies.Append(cookieName, value.ToString(), cookieOptions);
            

            return Ok(new { message = $"coockie successfully added {cookieName}" });

        }

        [HttpGet("  ")]
        public IActionResult readCoockie()
        {
            string cookieName = "Main";
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(7);
            string data = Request.Cookies[cookieName];
           
            return Ok(data);

        }
        [HttpGet("deleteCoockie")]
        public IActionResult deleteCookie()
        {

            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string value = Convert.ToBase64String(time.Concat(key).ToArray());

            //  var value2 = Convert.ToBase64CharArray(key, 80, 300, i, 4);

            // string cookieName = "testCookie01";
            string cookieName = "Main";
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(-7);

            Response.Cookies.Append(cookieName, value.ToString(), cookieOptions);


            return Ok(new { message = $"coockie successfully deleted {cookieName}" });

        }
    }
   

}




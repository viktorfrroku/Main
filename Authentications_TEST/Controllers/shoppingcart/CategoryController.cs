using Authentications_TEST.Connections;
using Authentications_TEST.Models.shppingCardModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Authentications_TEST.Controllers.shoppingcart
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        protected readonly DBConnection _con;
        public CategoryController(DBConnection connection) { 
          _con = connection;
        }
        // GET: CategoryController
        [HttpGet]
        public IEnumerable<product_category> category() {
            IEnumerable<product_category> data = _con.product_category.ToList();
            return data;            
        }

    }
}

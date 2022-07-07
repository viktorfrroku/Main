using Authentications_TEST.Connections;
using Authentications_TEST.Models.shppingCardModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Authentications_TEST.Controllers.shoppingcart
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: ProductController
        protected readonly DBConnection _con;
        public ProductController(DBConnection connection) { 
            _con = connection;
        }

        [HttpGet]
        public IEnumerable<product> product()
        {
            IEnumerable<product> pd = _con.product.ToList();
            if (pd != null)
                return pd;
            else
                return null;

        }
        [HttpGet("{id}")]
        public ActionResult<product> getProduct(int id)
        { 
         var data = _con.product.FirstOrDefault(x => x.id == id);
           if (data != null)
                return data;
           else 
                return null;
        
        }
    }
}

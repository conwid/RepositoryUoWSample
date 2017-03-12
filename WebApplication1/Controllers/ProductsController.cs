using Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController
    {
        private readonly IProductManager productManager;
        public ProductsController(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        [HttpGet]
        [Route()]
        public IHttpActionResult Get()
        {
            return Ok(productManager.GetAllProducts());
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(productManager.GetProductById(id));
        }
    }
}

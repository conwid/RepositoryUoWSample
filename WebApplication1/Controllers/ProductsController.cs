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
        private readonly IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet, Route()]
        public IHttpActionResult Get() => Ok(productService.GetAllProducts());

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id) => Ok(productService.GetProductById(id));
    }
}

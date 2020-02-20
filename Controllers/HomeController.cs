using System.Collections.Generic;
using backoffice.Data;
using backoffice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backoffice.Controllers
{
    [ApiController]
    [Route("products")]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Product> Get([FromServices]DataContext context)
        {
            return context.Products.AsNoTracking();
        }

        [HttpPost]
        public Product Post([FromServices]DataContext context, [FromBody]Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<Product> GetAll([FromServices]DataContext context)
        {
            return context.Products.IgnoreQueryFilters().AsNoTracking();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Models;

namespace Webshop.Controllers
{
    
    public class ProductsController : ODataController
    {
        private readonly ApplicationDbContext dbContext;

        public ProductsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(dbContext.Products);
        }
        [EnableQuery]
        public IActionResult Get([FromODataUri] int key)
        {
            
            return Ok(dbContext.Products.Where(product=>product.Id == key));
        }

        public async Task<IActionResult> Post(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return Ok(product);
        }
    }
}
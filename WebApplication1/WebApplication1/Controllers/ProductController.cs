using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyDbContext db;
        public ProductController(MyDbContext db)
        {
            db = db;
        }

        [HttpGet]
        public IActionResult GetProductList()
        {
            var productList = db.product.ToList();
            return Ok(productList);
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int productId)
        {
            var product = db.product.SingleOrDefault(p=>p.productId==productId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

    }
}

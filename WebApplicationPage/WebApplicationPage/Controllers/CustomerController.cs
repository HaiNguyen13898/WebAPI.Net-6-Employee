using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationPage.Data;
using WebApplicationPage.Filter;
using WebApplicationPage.Models;
using WebApplicationPage.Wrappers;

namespace WebApplicationPage.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private DataContext db;
        public CustomerController(DataContext dataContext)
        {
            db = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await db.customers
                                    .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                    .Take(validFilter.PageSize)
                                    .ToListAsync();
            var totalRecords = await db.customers.CountAsync();
            return Ok(new PagedResponse<List<Customer>>(pagedData, validFilter.PageNumber, validFilter.PageSize));

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await db.customers.SingleOrDefaultAsync(x => x.Id == id);
            return Ok(new Response<Customer>(customer));
        }
    }
}

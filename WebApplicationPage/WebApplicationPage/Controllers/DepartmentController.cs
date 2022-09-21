using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationPage.Data;
using WebApplicationPage.Filter;
using WebApplicationPage.Models;
using WebApplicationPage.Service;
using WebApplicationPage.Wrappers;

namespace WebApplicationPage.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private DataContext dataContext;
        private IDepartmentRepository departmentRepository; 
        public DepartmentController(DataContext dataContext, IDepartmentRepository departmentRepository)
        {
            this.dataContext = dataContext;
            this.departmentRepository = departmentRepository;
        }


        [HttpGet]
        public async Task<IActionResult> getListPageDepartment([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await dataContext.Department
                        .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                        .Take(validFilter.PageSize)
                        .ToListAsync();
            return Ok(new PagedResponse<List<Department>>(pagedData, validFilter.PageNumber, validFilter.PageSize));
        }
    }
}

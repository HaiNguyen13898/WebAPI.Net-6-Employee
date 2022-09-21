using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationPage.Data;
using WebApplicationPage.Dto;
using WebApplicationPage.Filter;
using WebApplicationPage.Helpers;
using WebApplicationPage.Models;
using WebApplicationPage.Service;
using WebApplicationPage.Service.Impl;
using WebApplicationPage.Wrappers;

namespace WebApplicationPage.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private DataContext dataContext;
        private IUriService uriService;
        private IEmployeeRepository employeeRepository;

        public EmployeeController(DataContext dataContext, IUriService uriService, IEmployeeRepository employeeRepository)
        {
            this.dataContext = dataContext;
            this.uriService = uriService;
            this.employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getListPageEmployee([FromQuery] PaginationFilter filter, string name, string dateBirth, int? idDepartment)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            #region List-Search
            var list = dataContext.Employees.Include(e => e.Department).AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                list = list.Where(e =>
                // e.Name.ToLower().Contains(name) || e.Name.Contains(name));
                e.Name.ToLower().Contains(name.ToLower()));
            }
            if (!string.IsNullOrEmpty(dateBirth))
            {
                list = list.Where(e => e.DateBirth.Contains(dateBirth));
            }
            if (idDepartment.HasValue)
            {
                list = list.Where(e=> e.Department.Id == idDepartment);
            }
            #endregion

            list = list.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                        .Take(validFilter.PageSize);

            var pagedData = list.ToList();     
            var totalRecords = await dataContext.Employees.CountAsync();
            var pagedReponse = PaginationHelper.CreatePagedReponse<Employee>(pagedData, validFilter, totalRecords, uriService, route);
            return Ok(pagedReponse);

        }
        // GET: Employee by id
        [HttpGet("{id}")]
        public IActionResult getEmployeeById(int id)
        {
            try
            {
                var employee = employeeRepository.getEmployeeById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }


        // POST: Add new employee
        [HttpPost]
        public IActionResult createEmployee([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                var employee = employeeRepository.addEmployee(employeeDto);
                return Ok(employee);

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult updateEmployee(int id, EmployeeDto employeeDto)
        {
            Employee findEmployeeById = employeeRepository.getEmployeeById(id);
            if (findEmployeeById == null)
            {
                return NotFound();
            }
            employeeRepository.update(employeeDto);
            return Ok("Updated");
        }


        [HttpDelete("{id}")]
        public IActionResult deleteEmployee(int id)
        {
            Employee employee = employeeRepository.getEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
          employeeRepository.deleteById(id);
          return Ok("Value Deleted");
        }



    }
}

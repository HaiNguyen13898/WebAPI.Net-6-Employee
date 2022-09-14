using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI4.Data;
using WebAPI4.Dto;
using WebAPI4.Models;


namespace WebAPI4.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public EmployeeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployee()
        {
            var employee = await _dataContext.Employees.Include(e=>e.Department).ToListAsync();

            return employee;
    }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> CreateEmployee(Employee employee)
        {
            //var department = await _dataContext.Depart.FindAsync(employee.Department.Id);
            //if(department == null)
            //{
            //    return NotFound();
            //}

            //Department department1 = new Department();
            //department1.Id = department;

            //var employees = new Employee()
            //{
            //    Name = employee.Name,
            //    DateBirth = employee.DateBirth,
            //    Address = employee.Address,
            //    // DepartmentId = employee.Department.Id
            //    Department = department
            //};

            Employee employeeUP = new Employee();
            employeeUP.Name = employee.Name;
            employeeUP.DateBirth = employee.DateBirth;
            employeeUP.Address = employee.Address;
            employeeUP.DepartmentId = employee.Department.Id;
            
            //employeeUP.Department = await _dataContext.Depart
            //    .Where(d => d.Id.Equals(employee.Department.Id))
            //    .FirstOrDefaultAsync();

            await _dataContext.Employees.AddAsync(employeeUP);
            await _dataContext.SaveChangesAsync();
            return Ok(employee);

        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, Employee employee)
        {
            var UpdateEmployee = _dataContext.Employees.Find(id);
            if(UpdateEmployee == null)
            {
                return NotFound();
            }

            UpdateEmployee.Name = employee.Name;
            UpdateEmployee.Address = employee.Address;
            UpdateEmployee.DateBirth = employee.DateBirth;
            UpdateEmployee.DepartmentId = employee.Department.Id;

            await _dataContext.SaveChangesAsync();
            return Ok(UpdateEmployee);

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetEmployee([FromRoute] int id)
        {
            var employee = await _dataContext.Employees.Where(e => e.Id == id).ToListAsync();
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            var employee = await _dataContext.Employees.FindAsync(id);
            if(employee != null) { 
                _dataContext.Remove(employee);
                await _dataContext.SaveChangesAsync();
                return Ok(employee);
            }
            return NotFound();
        }




    }
}

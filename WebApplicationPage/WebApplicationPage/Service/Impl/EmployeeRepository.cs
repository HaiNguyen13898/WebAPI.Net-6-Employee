using Microsoft.EntityFrameworkCore;
using WebApplicationPage.Data;
using WebApplicationPage.Dto;
using WebApplicationPage.Models;

namespace WebApplicationPage.Service.Impl
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext dataContext;
        public EmployeeRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Employee addEmployee(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                Name = employeeDto.Name,
                DateBirth = employeeDto.DateBirth,
                Address = employeeDto.Address,
                DepartmentId = employeeDto.DepartmentId
            };
            dataContext.Add(employee);
            dataContext.SaveChanges();
            return employee;
        }

        public void deleteById(int id)
        {
            var employee = dataContext.Employees.SingleOrDefault(e => e.Id == id);
            if(employee != null)
            {
                dataContext.Remove(employee);
                dataContext.SaveChanges();
            }    
           
        }

        public Employee getEmployeeById(int id)
        {
            var employee = dataContext.Employees.Include(e => e.Department)
                                                .SingleOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return null;
            }
            return employee;

        }

        public void update(EmployeeDto employeeDto)
        {
            var employeeUpdate = dataContext.Employees.SingleOrDefault(e => e.Id == employeeDto.Id);
            employeeUpdate.Name = employeeDto.Name;
            employeeUpdate.Address = employeeDto.Address;
            employeeUpdate.DateBirth = employeeDto.DateBirth;
            employeeUpdate.DepartmentId = employeeDto.DepartmentId;
            dataContext.SaveChanges();
        }
    }
}

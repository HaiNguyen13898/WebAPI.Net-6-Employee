using WebApplicationPage.Dto;
using WebApplicationPage.Models;

namespace WebApplicationPage.Service
{
    public interface IEmployeeRepository
    {
        Employee getEmployeeById(int id);
        Employee addEmployee(EmployeeDto employeeDto);
        void update(EmployeeDto employeeDto);
        void deleteById(int id);
    }
}

using WebApplicationPage.Models;

namespace WebApplicationPage.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateBirth { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
       // public Department Department { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;


namespace WebApplicationPage.Dto
{
    public class EmployeeDto 
    {
        public int Id { get; set; }
        [StringLength(100, ErrorMessage = "Name too long")]

        public string Name { get; set; }

        public string DateBirth { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }   

    }
}
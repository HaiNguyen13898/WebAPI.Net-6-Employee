using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplicationPage.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public string Name { get; set; }
        public string DateBirth { get; set; }
        public string Address { get; set; }
        public virtual Department Department { get; set; }

    }
}

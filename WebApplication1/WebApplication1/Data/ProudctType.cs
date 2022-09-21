using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    public class ProudctType
    {
        public ProudctType() 
        {
            products = new HashSet<Product>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productTypeId { get; set; }
        [MaxLength(250)]
        [Required]
        public string name { get; set; }
        public virtual ICollection<Product> products { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productId { get; set; }
        [Required]
        [MaxLength(250)]
        public string name { get; set; }
        [Range(0, double.MaxValue)]
        public double price { get; set; }

        [ForeignKey("productTypeId")]
        public ProudctType proudctType { get; set; }
    }
}

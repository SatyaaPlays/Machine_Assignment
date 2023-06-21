using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MachineAssignment.Models
{
    public class Products
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string productName { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }

        public int Category_Id { get; set; }
        [ForeignKey("Category_Id")]
        public Category Category { get; set; }
    }
}

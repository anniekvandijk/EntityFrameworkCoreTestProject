using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameworkCoreTestProject.Models
{
    [Table("Product")]
    public class Product
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }

        public string UnitName { get; set; }
        public int UnitScale { get; set; }
        public long InStock { get; set; }
        public double Price { get; set; }
        public double DiscontinuedPrice { get; set; }

        public virtual ProductCategory Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

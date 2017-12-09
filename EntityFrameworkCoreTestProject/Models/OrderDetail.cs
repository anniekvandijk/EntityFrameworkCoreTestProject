using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameworkCoreTestProject.Models
{
    [Table("Order Details")]
    public class OrderDetail
    {

        [Column(Order = 1)]
        public long OrderId { get; set; }

        [Column(Order = 2)]
        public long ProductId { get; set; }

        public double Price { get; set; }
        public double Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }

}

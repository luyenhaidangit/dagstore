using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("ProductDiscount")]
    public class ProductDiscount
    {
        [Key , Column(Order = 0)]
        public int ProductID { get; set; }

        [Key, Column(Order = 1)]
        public int DiscountID { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { set; get; }

        [ForeignKey("DiscountID")]
        public Discount Discount { set; get; }

    }
}

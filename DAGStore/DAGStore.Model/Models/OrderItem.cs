using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    public class OrderItem
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int OrderID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal TotalTax { get; set; }

        [Required]
        public decimal TotalShipping { get; set; }

        [Required]
        public decimal TotalDiscount { get; set; }
    }
}
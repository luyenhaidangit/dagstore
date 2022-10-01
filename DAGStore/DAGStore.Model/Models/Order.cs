using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [MaxLength(4000)]
        public string ShippingAddress { get; set; }

        [Required]
        public bool OrderStatus { get; set; }

        [Required]
        public bool ShippingStatus { get; set; }

        [Required]
        public bool PaymentStatus { get; set; }

        [Required]
        public decimal OrderTax { get; set; }

        [Required]
        public decimal OrderShipping { get; set; }

        [Required]
        public decimal OrderDiscount { get; set; }

        [Required]
        public decimal OrderTotal { get; set; }

        public string CustomerOrderComment { get; set; }

        [Required]
        public DateTime CreateOn { get; set; }

        [Required]
        public DateTime UpdateOn { get; set; }
    }
}

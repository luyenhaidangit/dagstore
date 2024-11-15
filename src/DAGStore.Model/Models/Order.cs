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

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [Required]
        public string ShippingFormat { get; set; }

        [MaxLength(4000)]
        public string ShippingAddress { get; set; }

        [Required]
        public int OrderStatus { get; set; }

        [Required]
        public int PaymentFormat { get; set; }

        [Required]
        public int PaymentStatus { get; set; }

        [Required]
        public decimal OrderDiscount { get; set; }

        [Required]
        public decimal OrderTotal { get; set; }

        public string CustomerOrderComment { get; set; }

        [Required]
        public DateTime CreateOn { get; set; }

        public virtual IEnumerable<OrderItem> OrderItems { set; get; }
    }
}

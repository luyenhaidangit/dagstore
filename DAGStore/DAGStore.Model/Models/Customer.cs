using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [StringLength(10)]
        public string NumberPhone { get; set; }

        [MaxLength(500)]
        public string Email { get; set; }

        [MaxLength(500)]
        public string Andress { get; set; }

        [MaxLength(500)]
        public string DeliveryAndress { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public virtual IEnumerable<CustomerAndress> CustomerAndresss { set; get; }
    }
}
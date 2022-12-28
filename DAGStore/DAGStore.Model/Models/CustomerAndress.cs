using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("CustomerAndress")]
    public class CustomerAndress
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [StringLength(10)]
        public string NumberPhone { get; set; }

        [MaxLength(500)]
        public string Andress { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("ImportBill")]
    public class ImportBill
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        public string ImportBillID { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }

        [Required]
        public decimal TotalPriceBill { get; set; }

        [Required]
        public decimal TotalDiscount { get; set; }

        [Required]
        public decimal ActualPriceBill { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public DateTime CreateOn { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdateOn { get; set; } 
    }
}

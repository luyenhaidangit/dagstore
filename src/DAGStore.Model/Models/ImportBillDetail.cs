using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("ImportBillDetail")]
    public class ImportBillDetail
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int ImportBillID { get; set; }

        [ForeignKey("ImportBillID")]
        public virtual ImportBill ImportBill { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal ImportPrice { get; set; }

        [Required]
        public decimal Discount { get; set; }

        [Required]
        public decimal TotalImportPrice { get; set; }
    }
}

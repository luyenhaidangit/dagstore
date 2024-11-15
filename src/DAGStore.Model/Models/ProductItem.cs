using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("ProductItem")]
    public class ProductItem
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [Required]
        [MaxLength(500)]
        public string SKU { get; set; }

        [Required]
        public int InventoryQuantity { get; set; }

        [Required]
        public decimal CostPrice { get; set; }

        [Required]
        public decimal SellPrice { get; set; }

        [Required]
        public decimal SellPriceActual { get; set; }

        [Required]
        public bool Published { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public virtual IEnumerable<ProductConfiguration> ProductConfigurations { set; get; }
    }
}
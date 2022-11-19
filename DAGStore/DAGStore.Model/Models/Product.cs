using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [ForeignKey("Brand")]
        public int BrandID { get; set; }
        public Brand Brand { get; set; }

        [MaxLength(4000)]
        public string PicturePath { get; set; }

        [MaxLength(4000)]
        public string ShortDescription { get; set; }

        [MaxLength(4000)]
        public string ShortDescriptionEndow { get; set; }

        public string FullDescription { get; set; }

        [Required]
        public decimal CostPrice { get; set; }

        [Required]
        public decimal SellPrice { get; set; }

        [Required]
        public decimal SellPriceActual { get; set; }

        [Required]
        public int InventoryQuantity { get; set; }

        [Required]
        public int MinimumInventoryQuantity { get; set; }

        [Required]
        public int MaximumInventoryQuantity { get; set; }

        [Required]
        public int DisplayOrder { get; set; }

        [Required]
        public bool Published { get; set; }

        [Required]
        public bool Deleted { get; set; }
    }
}

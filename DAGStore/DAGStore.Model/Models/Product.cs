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

        [MaxLength(4000)]
        public string PicturePath { get; set; }

        [MaxLength(4000)]
        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        [Required]
        public bool ShowOnHomePage { get; set; }

        [MaxLength(500)]
        public string MetaKeywords { get; set; }

        [MaxLength(4000)]
        public string MetaDescription { get; set; }

        [MaxLength(500)]
        public string MetaTitle { get; set; }

        [Required]
        [MaxLength(500)]
        public string Alias { get; set; }

        [Required]
        public bool AllowCustomerReviews { get; set; }

        [Required]
        public bool IsShipEnabled { get; set; }

        public decimal? AdditionalShippingCharge { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal OldPrice { get; set; }

        [Required]
        public bool HasDiscountsApplied { get; set; }

        [Required]
        public int DisplayOrder { get; set; }

        [Required]
        public bool Published { get; set; }

        [Required]
        public DateTime CreateOn { get; set; }

        [Required]
        public DateTime UpdateOn { get; set; }
    }
}

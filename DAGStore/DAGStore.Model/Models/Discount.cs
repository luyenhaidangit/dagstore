using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("Discount")]
    public class Discount
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [Required]
        public bool UsePercentage { get; set; }

        [Required]
        public decimal DiscountPercentage { get; set; }

        [Required]
        public decimal DiscountAmount { get; set; }

        [Required]
        public bool RequiresCouponCode { get; set; }

        [Required]
        public decimal CouponCode { get; set; }

        [Required]
        public string Description { get; set; }

        [MaxLength(4000)]
        public string PicturePath { get; set; }

        [MaxLength(100)]
        public string ColorBackGround { get; set; }

        [MaxLength(100)]
        public string ColorText { get; set; }

    }
}

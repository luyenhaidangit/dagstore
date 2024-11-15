using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("ProductConfiguration")]
    public class ProductConfiguration
    {
        [Key, Column(Order = 0)]
        public int? ProductItemID { get; set; }

        [Key, Column(Order = 1)]
        public int? VariationOptionID { get; set; }

        [ForeignKey("ProductItemID")]
        public ProductItem ProductItem { set; get; }

        [ForeignKey("VariationOptionID")]
        public VariationOption VariationOption { set; get; }

        //public int VariationOptionID { get; set; }
        //public VariationOption VariationOption { get; set; }

        //public int ProductItemID { get; set; }
        //public ProductItem ProductItem { get; set; }

    }
}
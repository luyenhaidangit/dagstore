using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("SuggestProduct")]
    public class SuggestProduct
    {
        [Key, Column(Order = 0)]
        public int SuggestID { get; set; }

        [Key, Column(Order = 1)]
        public int ProductID { get; set; }

        [ForeignKey("SuggestID")]
        public Suggest Suggest { set; get; }

        [ForeignKey("ProductID")]
        public Product Product { set; get; }
    }
}
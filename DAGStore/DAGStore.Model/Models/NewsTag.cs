using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("NewsTag")]
    public class NewsTag
    {
        [Key]
        [Column(Order = 1)]
        public int NewsID { set; get; }

        [Key]
        [Column(TypeName = "varchar", Order = 2)]
        [MaxLength(50)]
        public string TagID { set; get; }

        [ForeignKey("NewsID")]
        public virtual News News { set; get; }

        [ForeignKey("TagID")]
        public virtual Tag Tag { set; get; }
    }
}
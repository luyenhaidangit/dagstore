using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("SliderItem")]
    public class SliderItem
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int SliderID { set; get; }

        [MaxLength(500)]
        public string Content { get; set; }

        [MaxLength(4000)]
        public string ImagePath { get; set; }

        [MaxLength(4000)]
        public string URL { get; set; }

        [Required]
        public int DisplayOrder { get; set; }

        [ForeignKey("SliderID")]
        public virtual Slider Slider { set; get; }
    }
}
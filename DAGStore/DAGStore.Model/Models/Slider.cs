using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("Slider")]
    public class Slider
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(500)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Position { get; set; }

        [MaxLength(500)]
        public string TypeSlider { get; set; }

        [MaxLength(500)]
        public string Page { get; set; }

        [MaxLength(4000)]
        public string BackgroundColor { get; set; }

        [Required]
        public int DisplayOrder { get; set; }

        [Required]
        public bool Status { get; set; }

        public virtual IEnumerable<SliderItem> SliderItems { set; get; }
    }
}
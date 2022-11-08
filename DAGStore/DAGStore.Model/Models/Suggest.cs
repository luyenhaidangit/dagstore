using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("Suggest")]
    public class Suggest
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(500)]
        public string Title { get; set; }

        [MaxLength(4000)]
        public string ImagePath { get; set; }

        [MaxLength(500)]
        public string TextColor { get; set; }

        [MaxLength(500)]
        public string BackgroundColor { get; set; }

        public int SliderID { get; set; }

        public int DisplayOrder { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public bool ShowOnHomePage { get; set; }

        public virtual Slider Slider { get; set; }

        public virtual IEnumerable<SuggestProduct> SuggestProducts { set; get; }
    }
}
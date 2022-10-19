using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("Brand")]
    public class Brand
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [MaxLength(4000)]
        public string PicturePath { get; set; }

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
        public bool Published { get; set; }

        [Required]
        public int DisplayOrder { get; set; }
    }
}

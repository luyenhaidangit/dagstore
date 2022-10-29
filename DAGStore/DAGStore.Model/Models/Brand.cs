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

        public string Description { get; set; }

        [Required]
        public int DisplayOrder { get; set; }

        [Required]
        public bool Published { get; set; }

        [Required]
        public bool Deleted { get; set; }
    }
}

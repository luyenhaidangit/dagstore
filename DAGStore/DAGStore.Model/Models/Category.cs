using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int ParentCategoryID { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [MaxLength(4000)]
        public string PicturePath { get; set; }

        public string Description { get; set; }

        [Required]
        [MaxLength(500)]
        public string Alias { get; set; }

        [Required]
        public int DisplayOrder { get; set; }

        [Required]
        public bool ShowOnHomePage { get; set; }

        [Required]
        public bool Published { get; set; }

        [Required]
        public bool Deleted { get; set; }
    }
}
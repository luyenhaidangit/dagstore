using System;
using System.Collections.Generic;
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
        public bool ShowOnHomePage { get; set; }

        [Required]
        public bool Published { get; set; }

        [Required]
        public int DisplayOrder { get; set; }
    }
}
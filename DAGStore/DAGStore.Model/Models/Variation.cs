using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("Variation")]
    public class Variation
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
    }
}
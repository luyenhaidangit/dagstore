using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("VariationOption")]
    public class VariationOption
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Variation")]
        public int VariationID { get; set; }
        public Variation Variation { get; set; }

        [Required]
        [MaxLength(500)]
        public string Value { get; set; }
    }
}
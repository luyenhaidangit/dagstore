using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("MenuRecord")]
    public class MenuRecord
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Template { get; set; }

        [MaxLength(500)]
        public string WidgetZone { get; set; }

        [Required]
        public bool Published { get; set; }

        [Required]
        public int DisplayOrder { get; set; }

        public string ContentBody { get; set; }

        public virtual IEnumerable<MenuItemRecord> MenuItemRecords { get; set; }
    }
}
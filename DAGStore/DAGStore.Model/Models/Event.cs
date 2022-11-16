using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("Event")]
    public class Event
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(500)]
        public string Title { get; set; }

        [MaxLength(4000)]
        public string ImagePath { get; set; }

        public string FullDescription { get; set; }

        public int DisplayOrder { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public bool ShowOnHomePage { get; set; }
    }
}
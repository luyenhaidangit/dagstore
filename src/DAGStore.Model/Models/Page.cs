using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("Page")]
    public class Page
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(500)]
        public string Title { get; set; }

        [MaxLength(4000)]
        public string PictureAvatar { get; set; }

        public string Content { get; set; }

        [Required]
        public string Alias { get; set; }
    }
}
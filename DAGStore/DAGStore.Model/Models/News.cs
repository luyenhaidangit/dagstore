using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("News")]
    public class News
    {
        [Key]
        public int ID { get; set; }

        
    }
}
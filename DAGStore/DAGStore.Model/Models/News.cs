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

        [MaxLength(500)]
        public string Title { get; set; }

        [MaxLength(4000)]
        public string PictureAvatar { get; set; }

        public string Content { get; set; }

        public int ViewCount { get; set; }

        public string Tag { get; set; }

        public DateTime? CreateOn { get; set; }

        public virtual IEnumerable<NewsTag> NewsTags { set; get; }
    }
}
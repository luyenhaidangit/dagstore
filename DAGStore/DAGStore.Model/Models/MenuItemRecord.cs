using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAGStore.Model.Models
{
    [Table("MenuItemRecord")]
    public class MenuItemRecord
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int MenuRecordID { get; set; }

        [Required]
        public int ParentMenuItemRecordID { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProviderName { get; set; }

        [Required]
        public string Model { get; set; }

        [MaxLength(1000)]
        public string Title { get; set; }

        [Required]
        public bool Published { get; set; }

        [Required]
        public int DisplayOrder { get; set; }

        [MaxLength(100)]
        public string Icon { get; set; }

        [MaxLength(500)]
        public string HtmlID { get; set; }

        [MaxLength(500)]
        public string CssClass { get; set; }

        [MaxLength(500)]
        public string IconColor { get; set; }

        [ForeignKey("ID")]
        public virtual MenuRecord MenuRecord { set; get; }
    }
}
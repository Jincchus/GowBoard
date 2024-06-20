using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GowBoard.Models.Entity
{
    public class BoardContent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BoardContentId { get; set; }

        [Required]
        [StringLength(20)]
        public string Category { get; set; }

        [Required]
        [StringLength(50)]
        [ForeignKey("member_id")]
        public string WriterId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }


        public int ViewCount { get; set; } = 0;

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }


        public DateTime? ModifiedAt { get; set; }


        public string ModifierId { get; set; }

        [ForeignKey("member_id")]
        public virtual Member Member { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GowBoard.Models.Entity
{
    [Table("board_comment")]
    public class BoardComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("board_comment_id")]
        public int BoardCommentId { get; set; }

        [Required]
        [Column("board_content_id")]
        public int BoardContentId { get; set; }

        [Required]
        [Column("content", TypeName = "nvarchar(MAX)")]
        public string Content { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("parent_comment_id")]
        public int? ParentCommentId { get; set; }

        [ForeignKey("BoardContentId")]
        public virtual BoardContent BoardContent { get; set; }

        [ForeignKey("WriterId")]
        public virtual Member Member { get; set; }
    }
}
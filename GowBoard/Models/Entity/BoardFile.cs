using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GowBoard.Models.Entity
{
    [Table("board_file")]
    public class BoardFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("board_file_id")]
        public int BoardFileId { get; set; }

        [Required]
        [Column("board_content_id")]
        public int BoardContentId { get; set;}

        [Required]
        [Column("file_data", TypeName ="varbinary(MAX)")]
        public byte[] FileData { get; set; }

        [Required]
        [StringLength(255)]
        [Column("file_name")]
        public string FileName { get; set; }

        [Required]
        [StringLength(10)]
        [Column("extension")]
        public string Extension { get; set; }

        [Required]
        [Column("file_size")]
        public int FileSize { get; set; }

        [StringLength (50)]   
        [Column("file_mime_type")]
        public string FileMimeType { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("BoardContentId")]
        public virtual BoardContent BoardContent { get; set; }
    }
}
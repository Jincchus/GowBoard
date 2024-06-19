using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GowBoard.Models.Entity
{
    public class BoardFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BoardFileId { get; set; }

        [Required]
        public int BoardContentId { get; set;}

        [Required]
        public String FileData { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public int FileSize { get; set; }

        [Required]
        public string FileMimeType { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
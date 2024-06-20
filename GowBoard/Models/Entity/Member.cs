using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GowBoard.Models.Entity
{
    [Table("member")]
    public class Member
    {
        [Key]
        [Required]
        [StringLength(50)]
        [Column("member_id")]
        public string MemberId { get; set; }

        [Required]
        [StringLength(255)]
        [Column("password")]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        [Index(IsUnique = true)]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        [Column("nickname")]
        public string Nickname { get; set; }

        [StringLength(20)]
        [Column("phone")]
        public string Phone { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        [Column("delete_yn")]
        public bool DeleteYn { get; set; } = false;

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<MemberRoleMap> MemberRoleMap { get; set; }
    }
}
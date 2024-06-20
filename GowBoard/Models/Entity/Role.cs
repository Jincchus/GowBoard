using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GowBoard.Models.Entity
{
    [Table("role")]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("role_id")]
        public int RoleId { get; set; }

        [Required]
        [StringLength(20)]
        [Column("role_name")]
        public string RoleName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<MemberRoleMap> MemberRoleMap { get; set; }
    }
}
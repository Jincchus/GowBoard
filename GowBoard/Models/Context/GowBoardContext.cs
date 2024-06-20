using GowBoard.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GowBoard.Models.Context
{
    public class GowBoardContext : DbContext
    {
        public GowBoardContext() : base("name=BoardContextConnectionString") { }

        public DbSet<Member> Member { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<MemberRoleMap> MemberRoleMap { get; set; }
        public DbSet<BoardContent> BoardContent { get; set; }
        public DbSet<BoardFile> BoardFile { get; set; }
        public DbSet<BoardComment> BoardCommnet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberRoleMap>()
                .HasKey(mrm => new { mrm.MemberId, mrm.RoleId });

            modelBuilder.Entity<MemberRoleMap>()
                .HasRequired(mrm => mrm.Member)
                .WithMany(m => m.MemberRoleMap)
                .HasForeignKey(mrm => mrm.RoleId);

            //modelBuilder.Entity<BoardFile>()
            //    .HasRequired( bf => bf.BoardContentId )
            //    .WithMany( bc => bc.BoardFile)
            //    .HasForeignKey( bf => bf.BoardContentId );

            //modelBuilder.Entity<BoardComment>()
            //    .HasRequired(bc => bc.Writer)
            //    .WithMany(m => m.BoardComment)
            //    .HasForeignKey(bc => bc.WriterId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
using GowBoard.Models.Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GowBoard.Models.Context
{
    public class GowBoardContext : DbContext
    {
        public GowBoardContext() : base("GowBoardContext") { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<MemberRoleMap> MemberRoleMaps { get; set; }
        public DbSet<BoardContent> BoardContents { get; set; }
        public DbSet<BoardFile> BoardFiles { get; set; }
        public DbSet<BoardComment> BoardCommnets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            modelBuilder.Entity<MemberRoleMap>()
                .HasKey(mrm => new { mrm.MemberId, mrm.RoleId });

            modelBuilder.Entity<BoardComment>()
                .HasOptional(bc => bc.ParentComment)
                .WithMany(bc => bc.Replies)
                .HasForeignKey(bc => bc.ParentCommentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
namespace GowBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePrimaryKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.member_role_map", "member_id", "dbo.member");
            DropForeignKey("dbo.board_content", "modifier_id", "dbo.member");
            DropForeignKey("dbo.board_content", "writer_id", "dbo.member");
            DropForeignKey("dbo.board_comment", "writer_id", "dbo.member");
            DropPrimaryKey("dbo.member");
            AlterColumn("dbo.member", "member_id", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.member", "member_id");
            AddForeignKey("dbo.member_role_map", "member_id", "dbo.member", "member_id", cascadeDelete: true);
            AddForeignKey("dbo.board_content", "modifier_id", "dbo.member", "member_id");
            AddForeignKey("dbo.board_content", "writer_id", "dbo.member", "member_id");
            AddForeignKey("dbo.board_comment", "writer_id", "dbo.member", "member_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.board_comment", "writer_id", "dbo.member");
            DropForeignKey("dbo.board_content", "writer_id", "dbo.member");
            DropForeignKey("dbo.board_content", "modifier_id", "dbo.member");
            DropForeignKey("dbo.member_role_map", "member_id", "dbo.member");
            DropPrimaryKey("dbo.member");
            AlterColumn("dbo.member", "member_id", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.member", "member_id");
            AddForeignKey("dbo.board_comment", "writer_id", "dbo.member", "member_id", cascadeDelete: true);
            AddForeignKey("dbo.board_content", "writer_id", "dbo.member", "member_id");
            AddForeignKey("dbo.board_content", "modifier_id", "dbo.member", "member_id");
            AddForeignKey("dbo.member_role_map", "member_id", "dbo.member", "member_id", cascadeDelete: true);
        }
    }
}

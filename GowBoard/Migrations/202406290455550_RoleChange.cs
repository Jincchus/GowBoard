namespace GowBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.role", "created_at", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.role", "created_at", c => c.DateTime(nullable: false));
        }
    }
}

namespace GowBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.member", "created_at", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.member", "created_at", c => c.DateTime(nullable: false));
        }
    }
}

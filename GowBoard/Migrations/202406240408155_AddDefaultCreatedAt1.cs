namespace GowBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultCreatedAt1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Member", "created_at", c => c.DateTime(nullable: false, storeType: "datetime2", defaultValue: DateTime.Now));
        }

        public override void Down()
        {
            AlterColumn("dbo.Member", "created_at", c => c.DateTime(nullable: false));
        }
    }
}

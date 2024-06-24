namespace GowBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultCreatedAt : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE dbo.member ADD CONSTRAINT DF_member_created_at DEFAULT GETDATE() FOR created_at");
        }
        
        public override void Down()
        {
            Sql("ALTER TABLE dbo.member DROP CONSTRAINT DF_member_created_at");
        }
    }
}

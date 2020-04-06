namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedProfileAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profiles", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Profiles", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Profiles", "UserName", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profiles", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Profiles", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Profiles", "FirstName", c => c.String(nullable: false));
        }
    }
}

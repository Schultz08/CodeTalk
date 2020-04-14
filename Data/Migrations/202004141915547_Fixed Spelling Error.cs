namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedSpellingError : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryDescription", c => c.String(nullable: false));
            AddColumn("dbo.CodeExamples", "ExampleDescription", c => c.String(nullable: false));
            DropColumn("dbo.Categories", "CategoryDiscription");
            DropColumn("dbo.CodeExamples", "ExampleDiscription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CodeExamples", "ExampleDiscription", c => c.String(nullable: false));
            AddColumn("dbo.Categories", "CategoryDiscription", c => c.String(nullable: false));
            DropColumn("dbo.CodeExamples", "ExampleDescription");
            DropColumn("dbo.Categories", "CategoryDescription");
        }
    }
}

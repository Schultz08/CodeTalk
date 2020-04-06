namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedCodeExampleclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CodeExample_CodeExampleId", c => c.Int());
            CreateIndex("dbo.Categories", "CodeExample_CodeExampleId");
            AddForeignKey("dbo.Categories", "CodeExample_CodeExampleId", "dbo.CodeExamples", "CodeExampleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "CodeExample_CodeExampleId", "dbo.CodeExamples");
            DropIndex("dbo.Categories", new[] { "CodeExample_CodeExampleId" });
            DropColumn("dbo.Categories", "CodeExample_CodeExampleId");
        }
    }
}

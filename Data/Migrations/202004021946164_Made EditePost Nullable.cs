namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeEditePostNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CodeExamples", "EditedPost", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CodeExamples", "EditedPost", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}

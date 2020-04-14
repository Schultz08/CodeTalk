namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRateforUpVote : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rates", "CodeExampleId", "dbo.CodeExamples");
            DropForeignKey("dbo.Rates", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.Rates", new[] { "CodeExampleId" });
            DropIndex("dbo.Rates", new[] { "ProfileId" });
            DropColumn("dbo.CodeExamples", "AverageRating");
            DropColumn("dbo.Profiles", "AverageRating");
            DropColumn("dbo.Likes", "LikeCount");
            DropTable("dbo.Rates");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        RateId = c.Int(nullable: false, identity: true),
                        MyRating = c.Double(nullable: false),
                        Review = c.String(),
                        CodeExampleId = c.Int(nullable: false),
                        ProfileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RateId);
            
            AddColumn("dbo.Likes", "LikeCount", c => c.Int(nullable: false));
            AddColumn("dbo.Profiles", "AverageRating", c => c.Double(nullable: false));
            AddColumn("dbo.CodeExamples", "AverageRating", c => c.Double(nullable: false));
            CreateIndex("dbo.Rates", "ProfileId");
            CreateIndex("dbo.Rates", "CodeExampleId");
            AddForeignKey("dbo.Rates", "ProfileId", "dbo.Profiles", "ProfileId");
            AddForeignKey("dbo.Rates", "CodeExampleId", "dbo.CodeExamples", "CodeExampleId", cascadeDelete: true);
        }
    }
}

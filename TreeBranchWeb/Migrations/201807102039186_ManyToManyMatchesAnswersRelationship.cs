namespace TreeBranchWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyMatchesAnswersRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "Match_Id", "dbo.Matches");
            DropIndex("dbo.Answers", new[] { "Match_Id" });
            CreateTable(
                "dbo.AnswerMatches",
                c => new
                    {
                        Answer_Id = c.Int(nullable: false),
                        Match_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Answer_Id, t.Match_Id })
                .ForeignKey("dbo.Answers", t => t.Answer_Id, cascadeDelete: false)
                .ForeignKey("dbo.Matches", t => t.Match_Id, cascadeDelete: false)
                .Index(t => t.Answer_Id)
                .Index(t => t.Match_Id);
            
            DropColumn("dbo.Answers", "Match_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "Match_Id", c => c.Int());
            DropForeignKey("dbo.AnswerMatches", "Match_Id", "dbo.Matches");
            DropForeignKey("dbo.AnswerMatches", "Answer_Id", "dbo.Answers");
            DropIndex("dbo.AnswerMatches", new[] { "Match_Id" });
            DropIndex("dbo.AnswerMatches", new[] { "Answer_Id" });
            DropTable("dbo.AnswerMatches");
            CreateIndex("dbo.Answers", "Match_Id");
            AddForeignKey("dbo.Answers", "Match_Id", "dbo.Matches", "Id");
        }
    }
}

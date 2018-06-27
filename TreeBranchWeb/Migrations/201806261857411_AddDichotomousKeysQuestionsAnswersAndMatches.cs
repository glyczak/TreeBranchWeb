namespace TreeBranchWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDichotomousKeysQuestionsAnswersAndMatches : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DichotomousKeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        QuestionsFinalized = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DichotomousKeyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DichotomousKeys", t => t.DichotomousKeyId, cascadeDelete: true)
                .Index(t => t.DichotomousKeyId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        DichotomousKeyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DichotomousKeys", t => t.DichotomousKeyId, cascadeDelete: true)
                .Index(t => t.DichotomousKeyId);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "DichotomousKeyId", "dbo.DichotomousKeys");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Matches", "DichotomousKeyId", "dbo.DichotomousKeys");
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "DichotomousKeyId" });
            DropIndex("dbo.Matches", new[] { "DichotomousKeyId" });
            DropTable("dbo.Answers");
            DropTable("dbo.Questions");
            DropTable("dbo.Matches");
            DropTable("dbo.DichotomousKeys");
        }
    }
}

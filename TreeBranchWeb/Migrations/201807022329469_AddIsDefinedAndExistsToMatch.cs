namespace TreeBranchWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDefinedAndExistsToMatch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "IsDefined", c => c.Boolean(nullable: false));
            AddColumn("dbo.Matches", "Exists", c => c.Boolean(nullable: false));
            AddColumn("dbo.Answers", "Match_Id", c => c.Int());
            CreateIndex("dbo.Answers", "Match_Id");
            AddForeignKey("dbo.Answers", "Match_Id", "dbo.Matches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "Match_Id", "dbo.Matches");
            DropIndex("dbo.Answers", new[] { "Match_Id" });
            DropColumn("dbo.Answers", "Match_Id");
            DropColumn("dbo.Matches", "Exists");
            DropColumn("dbo.Matches", "IsDefined");
        }
    }
}

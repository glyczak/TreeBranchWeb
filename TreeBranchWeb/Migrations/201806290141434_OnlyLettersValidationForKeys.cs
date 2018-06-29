namespace TreeBranchWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OnlyLettersValidationForKeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DichotomousKeys", "MatchesFinalized", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DichotomousKeys", "MatchesFinalized");
        }
    }
}

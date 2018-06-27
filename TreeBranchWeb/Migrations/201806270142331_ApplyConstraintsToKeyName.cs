namespace TreeBranchWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyConstraintsToKeyName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DichotomousKeys", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DichotomousKeys", "Name", c => c.String());
        }
    }
}

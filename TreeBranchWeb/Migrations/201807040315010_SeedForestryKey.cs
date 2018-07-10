namespace TreeBranchWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedForestryKey : DbMigration
    {
        public override void Up()
        {
            Sql(@"
SET IDENTITY_INSERT [dbo].[DichotomousKeys] ON
INSERT INTO [dbo].[DichotomousKeys] ([Id], [Name], [QuestionsFinalized], [MatchesFinalized]) VALUES (1, N'Forestry', 0, 0)
SET IDENTITY_INSERT [dbo].[DichotomousKeys] OFF
");
        }
        
        public override void Down()
        {
        }
    }
}

namespace ProjectManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProjectModels", "ProjectName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.ProjectModels", "ProjectCost", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjectModels", "ProjectCost", c => c.String(nullable: false));
            AlterColumn("dbo.ProjectModels", "ProjectName", c => c.String(nullable: false));
        }
    }
}

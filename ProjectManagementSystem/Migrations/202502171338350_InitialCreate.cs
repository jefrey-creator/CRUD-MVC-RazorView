namespace ProjectManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectModels",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false),
                        ProjectCost = c.String(nullable: false),
                        ProjectStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProjectModels");
        }
    }
}

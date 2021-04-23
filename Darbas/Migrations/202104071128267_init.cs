namespace Darbas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeProjects", "ProjectId", "dbo.ProjectDetails");
            DropForeignKey("dbo.ProjectDetails", "Project_ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectDetails", new[] { "Project_ProjectId" });
            AddColumn("dbo.Projects", "ProjectDetails", c => c.String());
            DropTable("dbo.ProjectDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProjectDetails",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectInfo = c.String(),
                        Project_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            DropColumn("dbo.Projects", "ProjectDetails");
            CreateIndex("dbo.ProjectDetails", "Project_ProjectId");
            AddForeignKey("dbo.ProjectDetails", "Project_ProjectId", "dbo.Projects", "ProjectId");
            AddForeignKey("dbo.EmployeeProjects", "ProjectId", "dbo.ProjectDetails", "ProjectId", cascadeDelete: true);
        }
    }
}

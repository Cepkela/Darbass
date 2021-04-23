namespace Darbas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.EmployeeProjects");
            AddPrimaryKey("dbo.EmployeeProjects", new[] { "Id", "EmployeeId", "ProjectId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.EmployeeProjects");
            AddPrimaryKey("dbo.EmployeeProjects", new[] { "EmployeeId", "ProjectId" });
        }
    }
}

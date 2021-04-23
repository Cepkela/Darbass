namespace Darbas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeInfoes",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeInfoes", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeInfoes", new[] { "EmployeeId" });
            DropTable("dbo.EmployeeInfoes");
        }
    }
}

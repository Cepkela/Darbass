namespace Darbas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeInfoes",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        Email = c.String(),
                        Number = c.String(),
                        Salary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            DropColumn("dbo.Employees", "Email");
            DropColumn("dbo.Employees", "Number");
            DropColumn("dbo.Employees", "Salary");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Salary", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "Number", c => c.String());
            AddColumn("dbo.Employees", "Email", c => c.String());
            DropForeignKey("dbo.EmployeeInfoes", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeInfoes", new[] { "EmployeeId" });
            DropTable("dbo.EmployeeInfoes");
        }
    }
}

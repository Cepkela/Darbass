namespace Darbas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeInfoes", "Id", "dbo.Employees");
            DropIndex("dbo.EmployeeInfoes", new[] { "Id" });
            AddColumn("dbo.Employees", "Email", c => c.String());
            AddColumn("dbo.Employees", "Number", c => c.String());
            AddColumn("dbo.Employees", "Salary", c => c.Int(nullable: false));
            DropTable("dbo.EmployeeInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmployeeInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Email = c.String(),
                        Number = c.String(),
                        Salary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Employees", "Salary");
            DropColumn("dbo.Employees", "Number");
            DropColumn("dbo.Employees", "Email");
            CreateIndex("dbo.EmployeeInfoes", "Id");
            AddForeignKey("dbo.EmployeeInfoes", "Id", "dbo.Employees", "EmployeeId");
        }
    }
}

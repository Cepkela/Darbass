namespace Darbas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.EmployeeInfoes", name: "EmployeeId", newName: "Id");
            RenameIndex(table: "dbo.EmployeeInfoes", name: "IX_EmployeeId", newName: "IX_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.EmployeeInfoes", name: "IX_Id", newName: "IX_EmployeeId");
            RenameColumn(table: "dbo.EmployeeInfoes", name: "Id", newName: "EmployeeId");
        }
    }
}

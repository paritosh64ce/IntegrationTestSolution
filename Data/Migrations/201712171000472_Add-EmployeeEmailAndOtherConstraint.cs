namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeEmailAndOtherConstraint : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Employees", "Email", c => c.String(nullable: false, maxLength: 50));
            //AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 50));
            //AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false, maxLength: 50));
            //AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false, maxLength: 50));
            //CreateIndex("dbo.Departments", "Name", unique: true, name: "IX_U_Department");
            //CreateIndex("dbo.Employees", "Email", unique: true, name: "IX_U_Email");
        }
        
        public override void Down()
        {
            //DropIndex("dbo.Employees", "IX_U_Email");
            //DropIndex("dbo.Departments", "IX_U_Department");
            //AlterColumn("dbo.Employees", "LastName", c => c.String());
            //AlterColumn("dbo.Employees", "FirstName", c => c.String());
            //AlterColumn("dbo.Departments", "Name", c => c.String());
            //DropColumn("dbo.Employees", "Email");
        }
    }
}

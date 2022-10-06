namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test12345 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Admins", "AdminRole_AdminRoleID", "dbo.AdminRoles");
            DropIndex("dbo.Admins", new[] { "AdminRole_AdminRoleID" });
            AddColumn("dbo.Admins", "AdminRolesID", c => c.Int(nullable: false));
            DropColumn("dbo.Admins", "AdminRolID");
            DropColumn("dbo.Admins", "AdminRole_AdminRoleID");
            DropTable("dbo.AdminRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AdminRoles",
                c => new
                    {
                        AdminRoleID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.AdminRoleID);
            
            AddColumn("dbo.Admins", "AdminRole_AdminRoleID", c => c.Int());
            AddColumn("dbo.Admins", "AdminRolID", c => c.Int(nullable: false));
            DropColumn("dbo.Admins", "AdminRolesID");
            CreateIndex("dbo.Admins", "AdminRole_AdminRoleID");
            AddForeignKey("dbo.Admins", "AdminRole_AdminRoleID", "dbo.AdminRoles", "AdminRoleID");
        }
    }
}

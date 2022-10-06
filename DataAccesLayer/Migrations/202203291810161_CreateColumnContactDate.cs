namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateColumnContactDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ContactDate");
        }
    }
}

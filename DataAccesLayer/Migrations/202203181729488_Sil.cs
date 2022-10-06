namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sil : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comments", "Tarih");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Tarih", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
    }
}

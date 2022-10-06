namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBlogColumnBlogRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "BlogRating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "BlogRating");
        }
    }
}

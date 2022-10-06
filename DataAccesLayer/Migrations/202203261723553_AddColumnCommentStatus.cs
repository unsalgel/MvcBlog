namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnCommentStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "CommentStatus");
        }
    }
}

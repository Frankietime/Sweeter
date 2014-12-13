namespace Sweeter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modif : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Favourites", "PostId", c => c.Int(nullable: false));
            AddColumn("dbo.Resweets", "PostId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserPosts", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserPosts", "DateTime", c => c.String());
            DropColumn("dbo.Resweets", "PostId");
            DropColumn("dbo.Favourites", "PostId");
        }
    }
}

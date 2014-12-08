namespace Sweeter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdToUserPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserPosts", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserPosts", "UserId");
        }
    }
}

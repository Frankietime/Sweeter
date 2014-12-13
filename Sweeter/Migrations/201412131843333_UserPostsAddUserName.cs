namespace Sweeter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPostsAddUserName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserPosts", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserPosts", "UserName");
        }
    }
}

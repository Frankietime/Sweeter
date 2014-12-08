namespace Sweeter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favourites",
                c => new
                    {
                        FavouriteId = c.Int(nullable: false, identity: true),
                        FromUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FavouriteId);
            
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        FriendId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FriendId);
            
            CreateTable(
                "dbo.UserMultimedias",
                c => new
                    {
                        UserMultimediaId = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.UserMultimediaId);
            
            CreateTable(
                "dbo.UserPosts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        DateTime = c.String(),
                    })
                .PrimaryKey(t => t.PostId);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        Legend = c.String(),
                        ProfilePhoto_UserMultimediaId = c.Int(),
                    })
                .PrimaryKey(t => t.ProfileId)
                .ForeignKey("dbo.UserMultimedias", t => t.ProfilePhoto_UserMultimediaId)
                .Index(t => t.ProfilePhoto_UserMultimediaId);
            
            CreateTable(
                "dbo.Resweets",
                c => new
                    {
                        ResweetId = c.Int(nullable: false, identity: true),
                        FromUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResweetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "ProfilePhoto_UserMultimediaId", "dbo.UserMultimedias");
            DropIndex("dbo.Profiles", new[] { "ProfilePhoto_UserMultimediaId" });
            DropTable("dbo.Resweets");
            DropTable("dbo.Profiles");
            DropTable("dbo.UserPosts");
            DropTable("dbo.UserMultimedias");
            DropTable("dbo.Friends");
            DropTable("dbo.Favourites");
        }
    }
}

namespace Sweeter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifUserPosts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserPosts", "Photo_UserMultimediaId", "dbo.UserMultimedias");
            DropPrimaryKey("dbo.UserMultimedias");
            AddColumn("dbo.UserMultimedias", "UserMultimediaId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.UserPosts", "UserPhoto", c => c.String());
            AddColumn("dbo.UserPosts", "Photo_UserMultimediaId", c => c.Int());
            AlterColumn("dbo.UserMultimedias", "UserId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UserMultimedias", "UserMultimediaId");
            CreateIndex("dbo.UserPosts", "Photo_UserMultimediaId");
            AddForeignKey("dbo.UserPosts", "Photo_UserMultimediaId", "dbo.UserMultimedias", "UserMultimediaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPosts", "Photo_UserMultimediaId", "dbo.UserMultimedias");
            DropIndex("dbo.UserPosts", new[] { "Photo_UserMultimediaId" });
            DropPrimaryKey("dbo.UserMultimedias");
            AlterColumn("dbo.UserMultimedias", "UserId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.UserPosts", "Photo_UserMultimediaId");
            DropColumn("dbo.UserPosts", "UserPhoto");
            DropColumn("dbo.UserMultimedias", "UserMultimediaId");
            AddPrimaryKey("dbo.UserMultimedias", "UserId");
            AddForeignKey("dbo.UserPosts", "Photo_UserMultimediaId", "dbo.UserMultimedias", "UserMultimediaId");
        }
    }
}

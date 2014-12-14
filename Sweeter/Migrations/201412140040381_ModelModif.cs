namespace Sweeter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelModif : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "ProfilePhoto_UserMultimediaId", "dbo.UserMultimedias");
            DropIndex("dbo.Profiles", new[] { "ProfilePhoto_UserMultimediaId" });
            DropPrimaryKey("dbo.UserMultimedias");
            AddColumn("dbo.UserMultimedias", "PhotoPath", c => c.String());
            AddColumn("dbo.UserMultimedias", "Legend", c => c.String());
            AddColumn("dbo.Profiles", "PhotoPath", c => c.String());
            AlterColumn("dbo.UserMultimedias", "UserId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserMultimedias", "UserId");
            DropColumn("dbo.UserMultimedias", "UserMultimediaId");
            DropColumn("dbo.UserMultimedias", "Path");
            DropColumn("dbo.UserMultimedias", "Description");
            DropColumn("dbo.Profiles", "ProfilePhoto_UserMultimediaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "ProfilePhoto_UserMultimediaId", c => c.Int());
            AddColumn("dbo.UserMultimedias", "Description", c => c.String());
            AddColumn("dbo.UserMultimedias", "Path", c => c.String());
            AddColumn("dbo.UserMultimedias", "UserMultimediaId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.UserMultimedias");
            AlterColumn("dbo.UserMultimedias", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Profiles", "PhotoPath");
            DropColumn("dbo.UserMultimedias", "Legend");
            DropColumn("dbo.UserMultimedias", "PhotoPath");
            AddPrimaryKey("dbo.UserMultimedias", "UserMultimediaId");
            CreateIndex("dbo.Profiles", "ProfilePhoto_UserMultimediaId");
            AddForeignKey("dbo.Profiles", "ProfilePhoto_UserMultimediaId", "dbo.UserMultimedias", "UserMultimediaId");
        }
    }
}

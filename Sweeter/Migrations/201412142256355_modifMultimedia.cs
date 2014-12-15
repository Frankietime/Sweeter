namespace Sweeter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifMultimedia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserMultimedias", "Type", c => c.String());
            AddColumn("dbo.UserMultimedias", "Path", c => c.String());
            DropColumn("dbo.UserMultimedias", "PhotoPath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserMultimedias", "PhotoPath", c => c.String());
            DropColumn("dbo.UserMultimedias", "Path");
            DropColumn("dbo.UserMultimedias", "Type");
        }
    }
}

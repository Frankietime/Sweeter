namespace Sweeter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifProfiles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "UserName");
        }
    }
}

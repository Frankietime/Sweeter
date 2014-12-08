namespace Sweeter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyFriends : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Friends", "RelationshipId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Friends", "RelationshipId");
        }
    }
}

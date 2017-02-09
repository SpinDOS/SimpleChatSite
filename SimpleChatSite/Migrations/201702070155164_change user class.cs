namespace SimpleChatSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeuserclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "RealName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "RealName");
        }
    }
}

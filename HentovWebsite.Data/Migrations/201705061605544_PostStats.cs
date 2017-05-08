namespace HentovWebsite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostStats : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WebsiteUsers", "PostEntityModel_Id", c => c.Int());
            CreateIndex("dbo.WebsiteUsers", "PostEntityModel_Id");
            AddForeignKey("dbo.WebsiteUsers", "PostEntityModel_Id", "dbo.Posts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WebsiteUsers", "PostEntityModel_Id", "dbo.Posts");
            DropIndex("dbo.WebsiteUsers", new[] { "PostEntityModel_Id" });
            DropColumn("dbo.WebsiteUsers", "PostEntityModel_Id");
        }
    }
}

namespace HentovWebsite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedPostLiking2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WebsiteUsers", "PostEntityModel_Id", "dbo.Posts");
            DropIndex("dbo.WebsiteUsers", new[] { "PostEntityModel_Id" });
            CreateTable(
                "dbo.WebsiteUserPostEntityModels",
                c => new
                    {
                        WebsiteUser_Id = c.Int(nullable: false),
                        PostEntityModel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WebsiteUser_Id, t.PostEntityModel_Id })
                .ForeignKey("dbo.WebsiteUsers", t => t.WebsiteUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.PostEntityModel_Id, cascadeDelete: true)
                .Index(t => t.WebsiteUser_Id)
                .Index(t => t.PostEntityModel_Id);
            
            DropColumn("dbo.WebsiteUsers", "PostEntityModel_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WebsiteUsers", "PostEntityModel_Id", c => c.Int());
            DropForeignKey("dbo.WebsiteUserPostEntityModels", "PostEntityModel_Id", "dbo.Posts");
            DropForeignKey("dbo.WebsiteUserPostEntityModels", "WebsiteUser_Id", "dbo.WebsiteUsers");
            DropIndex("dbo.WebsiteUserPostEntityModels", new[] { "PostEntityModel_Id" });
            DropIndex("dbo.WebsiteUserPostEntityModels", new[] { "WebsiteUser_Id" });
            DropTable("dbo.WebsiteUserPostEntityModels");
            CreateIndex("dbo.WebsiteUsers", "PostEntityModel_Id");
            AddForeignKey("dbo.WebsiteUsers", "PostEntityModel_Id", "dbo.Posts", "Id");
        }
    }
}

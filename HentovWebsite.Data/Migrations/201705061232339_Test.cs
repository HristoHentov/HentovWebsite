namespace HentovWebsite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TagEntityModels", newName: "Tags");
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(nullable: false, maxLength: 1600),
                        ProjectLink = c.String(nullable: false),
                        Thumbnail = c.String(nullable: false),
                        ProjectType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.WebsiteUsers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "AuthorName", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Posts", "Content", c => c.String(nullable: false, maxLength: 1600));
            AlterColumn("dbo.Posts", "AuthorName", c => c.String(nullable: false));
            AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Tutorials", "Thumbnail", c => c.String());
            AlterColumn("dbo.Tutorials", "Title", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Tutorials", "Description", c => c.String(nullable: false, maxLength: 1600));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tutorials", "Description", c => c.String());
            AlterColumn("dbo.Tutorials", "Title", c => c.String());
            AlterColumn("dbo.Tutorials", "Thumbnail", c => c.Binary());
            AlterColumn("dbo.Tags", "Name", c => c.String());
            AlterColumn("dbo.Posts", "AuthorName", c => c.String());
            AlterColumn("dbo.Posts", "Content", c => c.String());
            AlterColumn("dbo.Posts", "Title", c => c.String());
            AlterColumn("dbo.Comments", "AuthorName", c => c.String());
            DropColumn("dbo.WebsiteUsers", "Name");
            DropTable("dbo.Projects");
            RenameTable(name: "dbo.Tags", newName: "TagEntityModels");
        }
    }
}

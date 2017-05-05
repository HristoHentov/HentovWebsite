namespace HentovWebsite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "AuthorName", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Content", c => c.String(nullable: false, maxLength: 1600));
            AlterColumn("dbo.Projects", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Projects", "Description", c => c.String(nullable: false, maxLength: 1600));
            AlterColumn("dbo.Projects", "ProjectLink", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Thumbnail", c => c.String(nullable: false));
            AlterColumn("dbo.TagEntityModels", "Name", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Tutorials", "Description", c => c.String(nullable: false, maxLength: 1600));
            AlterColumn("dbo.WebsiteUsers", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WebsiteUsers", "Name", c => c.String());
            AlterColumn("dbo.Tutorials", "Description", c => c.String(maxLength: 3000));
            AlterColumn("dbo.TagEntityModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Thumbnail", c => c.String());
            AlterColumn("dbo.Projects", "ProjectLink", c => c.String());
            AlterColumn("dbo.Projects", "Description", c => c.String());
            AlterColumn("dbo.Projects", "Name", c => c.String());
            AlterColumn("dbo.Posts", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "AuthorName", c => c.String(nullable: false, maxLength: 20));
        }
    }
}

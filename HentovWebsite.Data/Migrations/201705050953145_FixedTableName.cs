namespace HentovWebsite.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class FixedTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TagEntityModels", newName: "Tags");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Tags", newName: "TagEntityModels");
        }
    }
}

namespace TelerikMvcApp4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Brand", c => c.String());
            AddColumn("dbo.Cars", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Type");
            DropColumn("dbo.Cars", "Brand");
        }
    }
}

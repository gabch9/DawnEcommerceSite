namespace Back_End.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class structureChangeTallas : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.EstiloDMTallaDMs", "NumeroTalla");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EstiloDMTallaDMs", "NumeroTalla", c => c.Int(nullable: false));
        }
    }
}

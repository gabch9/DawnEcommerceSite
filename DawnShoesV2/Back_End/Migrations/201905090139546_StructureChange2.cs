namespace Back_End.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StructureChange2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClasificacionZapatoDMs", "GeneroDMId", "dbo.GeneroDMs");
            DropIndex("dbo.ClasificacionZapatoDMs", new[] { "GeneroDMId" });
            AddColumn("dbo.EstiloDMTallaDMs", "NumeroTalla", c => c.Int(nullable: false));
            DropColumn("dbo.ClasificacionZapatoDMs", "GeneroDMId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClasificacionZapatoDMs", "GeneroDMId", c => c.Int(nullable: false));
            DropColumn("dbo.EstiloDMTallaDMs", "NumeroTalla");
            CreateIndex("dbo.ClasificacionZapatoDMs", "GeneroDMId");
            AddForeignKey("dbo.ClasificacionZapatoDMs", "GeneroDMId", "dbo.GeneroDMs", "GeneroDMId", cascadeDelete: true);
        }
    }
}

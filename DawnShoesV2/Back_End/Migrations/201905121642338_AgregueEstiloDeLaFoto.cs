namespace Back_End.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregueEstiloDeLaFoto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImagenEstiloDMs", "EstiloDM_EstiloDMId", "dbo.EstiloDMs");
            DropIndex("dbo.ImagenEstiloDMs", new[] { "EstiloDM_EstiloDMId" });
            RenameColumn(table: "dbo.ImagenEstiloDMs", name: "EstiloDM_EstiloDMId", newName: "EstiloDMId");
            AlterColumn("dbo.ImagenEstiloDMs", "EstiloDMId", c => c.Int(nullable: false));
            CreateIndex("dbo.ImagenEstiloDMs", "EstiloDMId");
            AddForeignKey("dbo.ImagenEstiloDMs", "EstiloDMId", "dbo.EstiloDMs", "EstiloDMId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImagenEstiloDMs", "EstiloDMId", "dbo.EstiloDMs");
            DropIndex("dbo.ImagenEstiloDMs", new[] { "EstiloDMId" });
            AlterColumn("dbo.ImagenEstiloDMs", "EstiloDMId", c => c.Int());
            RenameColumn(table: "dbo.ImagenEstiloDMs", name: "EstiloDMId", newName: "EstiloDM_EstiloDMId");
            CreateIndex("dbo.ImagenEstiloDMs", "EstiloDM_EstiloDMId");
            AddForeignKey("dbo.ImagenEstiloDMs", "EstiloDM_EstiloDMId", "dbo.EstiloDMs", "EstiloDMId");
        }
    }
}

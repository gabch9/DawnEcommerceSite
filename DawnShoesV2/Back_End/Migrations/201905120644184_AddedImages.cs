namespace Back_End.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImagenEstiloDMs",
                c => new
                    {
                        ImagenEstiloDMId = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        EstiloDM_EstiloDMId = c.Int(),
                    })
                .PrimaryKey(t => t.ImagenEstiloDMId)
                .ForeignKey("dbo.EstiloDMs", t => t.EstiloDM_EstiloDMId)
                .Index(t => t.EstiloDM_EstiloDMId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImagenEstiloDMs", "EstiloDM_EstiloDMId", "dbo.EstiloDMs");
            DropIndex("dbo.ImagenEstiloDMs", new[] { "EstiloDM_EstiloDMId" });
            DropTable("dbo.ImagenEstiloDMs");
        }
    }
}

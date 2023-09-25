namespace Back_End.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class estilosV1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.EstiloDMs", name: "ClasificacionZapatoDMId_ClasificacionZapatoDMId", newName: "ClasificacionZapatoDM_ClasificacionZapatoDMId");
            RenameColumn(table: "dbo.SerieZapatosDMs", name: "EstiloDM_EstiloDMId", newName: "Estilo_EstiloDMId");
            RenameColumn(table: "dbo.SerieZapatosDMs", name: "TallaDM_TallaDMId", newName: "Talla_TallaDMId");
            RenameIndex(table: "dbo.EstiloDMs", name: "IX_ClasificacionZapatoDMId_ClasificacionZapatoDMId", newName: "IX_ClasificacionZapatoDM_ClasificacionZapatoDMId");
            RenameIndex(table: "dbo.SerieZapatosDMs", name: "IX_EstiloDM_EstiloDMId", newName: "IX_Estilo_EstiloDMId");
            RenameIndex(table: "dbo.SerieZapatosDMs", name: "IX_TallaDM_TallaDMId", newName: "IX_Talla_TallaDMId");
            AlterColumn("dbo.ClasificacionZapatoDMs", "GeneroDM_GeneroDMId", c => c.Int());
            CreateIndex("dbo.ClasificacionZapatoDMs", "GeneroDM_GeneroDMId");
            AddForeignKey("dbo.ClasificacionZapatoDMs", "GeneroDM_GeneroDMId", "dbo.GeneroDMs", "GeneroDMId");
            DropColumn("dbo.EstiloDMs", "TieneDescuento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EstiloDMs", "TieneDescuento", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.ClasificacionZapatoDMs", "GeneroDM_GeneroDMId", "dbo.GeneroDMs");
            DropIndex("dbo.ClasificacionZapatoDMs", new[] { "GeneroDM_GeneroDMId" });
            AlterColumn("dbo.ClasificacionZapatoDMs", "GeneroDM_GeneroDMId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.SerieZapatosDMs", name: "IX_Talla_TallaDMId", newName: "IX_TallaDM_TallaDMId");
            RenameIndex(table: "dbo.SerieZapatosDMs", name: "IX_Estilo_EstiloDMId", newName: "IX_EstiloDM_EstiloDMId");
            RenameIndex(table: "dbo.EstiloDMs", name: "IX_ClasificacionZapatoDM_ClasificacionZapatoDMId", newName: "IX_ClasificacionZapatoDMId_ClasificacionZapatoDMId");
            RenameColumn(table: "dbo.SerieZapatosDMs", name: "Talla_TallaDMId", newName: "TallaDM_TallaDMId");
            RenameColumn(table: "dbo.SerieZapatosDMs", name: "Estilo_EstiloDMId", newName: "EstiloDM_EstiloDMId");
            RenameColumn(table: "dbo.EstiloDMs", name: "ClasificacionZapatoDM_ClasificacionZapatoDMId", newName: "ClasificacionZapatoDMId_ClasificacionZapatoDMId");
        }
    }
}

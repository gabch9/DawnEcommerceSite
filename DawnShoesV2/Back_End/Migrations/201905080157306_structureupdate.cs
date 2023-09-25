namespace Back_End.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class structureupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SerieZapatosDMs", "Estilo_EstiloDMId", "dbo.EstiloDMs");
            DropForeignKey("dbo.SerieZapatosDMs", "Talla_TallaDMId", "dbo.TallaDMs");
            DropForeignKey("dbo.ClasificacionZapatoDMs", "GeneroDM_GeneroDMId", "dbo.GeneroDMs");
            DropIndex("dbo.ClasificacionZapatoDMs", new[] { "GeneroDM_GeneroDMId" });
            DropIndex("dbo.SerieZapatosDMs", new[] { "Estilo_EstiloDMId" });
            DropIndex("dbo.SerieZapatosDMs", new[] { "Talla_TallaDMId" });
            RenameColumn(table: "dbo.ClasificacionZapatoDMs", name: "GeneroDM_GeneroDMId", newName: "GeneroDMId");
            RenameColumn(table: "dbo.EstiloDMs", name: "ClasificacionZapatoDM_ClasificacionZapatoDMId", newName: "ClasificacionZapatoDMId");
            RenameColumn(table: "dbo.EstiloDMs", name: "ColorDM_ColorDMId", newName: "ColorDMId");
            RenameColumn(table: "dbo.EstiloDMs", name: "EdadDM_EdadDMId", newName: "EdadDMId");
            RenameColumn(table: "dbo.EstiloDMs", name: "GeneroDM_GeneroDMId", newName: "GeneroDMId");
            RenameIndex(table: "dbo.EstiloDMs", name: "IX_GeneroDM_GeneroDMId", newName: "IX_GeneroDMId");
            RenameIndex(table: "dbo.EstiloDMs", name: "IX_ColorDM_ColorDMId", newName: "IX_ColorDMId");
            RenameIndex(table: "dbo.EstiloDMs", name: "IX_ClasificacionZapatoDM_ClasificacionZapatoDMId", newName: "IX_ClasificacionZapatoDMId");
            RenameIndex(table: "dbo.EstiloDMs", name: "IX_EdadDM_EdadDMId", newName: "IX_EdadDMId");
            CreateTable(
                "dbo.EstiloDMTallaDMs",
                c => new
                    {
                        EstiloDMTallaDMId = c.Int(nullable: false, identity: true),
                        CantidadDisponible = c.Int(nullable: false),
                        MedidaCM = c.Int(nullable: false),
                        EstiloDMId = c.Int(nullable: false),
                        TallaDMId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EstiloDMTallaDMId)
                .ForeignKey("dbo.EstiloDMs", t => t.EstiloDMId, cascadeDelete: true)
                .ForeignKey("dbo.TallaDMs", t => t.TallaDMId, cascadeDelete: true)
                .Index(t => t.EstiloDMId)
                .Index(t => t.TallaDMId);
            
            AlterColumn("dbo.ClasificacionZapatoDMs", "GeneroDMId", c => c.Int(nullable: false));
            CreateIndex("dbo.ClasificacionZapatoDMs", "GeneroDMId");
            AddForeignKey("dbo.ClasificacionZapatoDMs", "GeneroDMId", "dbo.GeneroDMs", "GeneroDMId", cascadeDelete: true);
            DropTable("dbo.SerieZapatosDMs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SerieZapatosDMs",
                c => new
                    {
                        SerieZapatosDMId = c.Int(nullable: false, identity: true),
                        CantidadDisponible = c.Int(nullable: false),
                        Estilo_EstiloDMId = c.Int(),
                        Talla_TallaDMId = c.Int(),
                    })
                .PrimaryKey(t => t.SerieZapatosDMId);
            
            DropForeignKey("dbo.ClasificacionZapatoDMs", "GeneroDMId", "dbo.GeneroDMs");
            DropForeignKey("dbo.EstiloDMTallaDMs", "TallaDMId", "dbo.TallaDMs");
            DropForeignKey("dbo.EstiloDMTallaDMs", "EstiloDMId", "dbo.EstiloDMs");
            DropIndex("dbo.EstiloDMTallaDMs", new[] { "TallaDMId" });
            DropIndex("dbo.EstiloDMTallaDMs", new[] { "EstiloDMId" });
            DropIndex("dbo.ClasificacionZapatoDMs", new[] { "GeneroDMId" });
            AlterColumn("dbo.ClasificacionZapatoDMs", "GeneroDMId", c => c.Int());
            DropTable("dbo.EstiloDMTallaDMs");
            RenameIndex(table: "dbo.EstiloDMs", name: "IX_EdadDMId", newName: "IX_EdadDM_EdadDMId");
            RenameIndex(table: "dbo.EstiloDMs", name: "IX_ClasificacionZapatoDMId", newName: "IX_ClasificacionZapatoDM_ClasificacionZapatoDMId");
            RenameIndex(table: "dbo.EstiloDMs", name: "IX_ColorDMId", newName: "IX_ColorDM_ColorDMId");
            RenameIndex(table: "dbo.EstiloDMs", name: "IX_GeneroDMId", newName: "IX_GeneroDM_GeneroDMId");
            RenameColumn(table: "dbo.EstiloDMs", name: "GeneroDMId", newName: "GeneroDM_GeneroDMId");
            RenameColumn(table: "dbo.EstiloDMs", name: "EdadDMId", newName: "EdadDM_EdadDMId");
            RenameColumn(table: "dbo.EstiloDMs", name: "ColorDMId", newName: "ColorDM_ColorDMId");
            RenameColumn(table: "dbo.EstiloDMs", name: "ClasificacionZapatoDMId", newName: "ClasificacionZapatoDM_ClasificacionZapatoDMId");
            RenameColumn(table: "dbo.ClasificacionZapatoDMs", name: "GeneroDMId", newName: "GeneroDM_GeneroDMId");
            CreateIndex("dbo.SerieZapatosDMs", "Talla_TallaDMId");
            CreateIndex("dbo.SerieZapatosDMs", "Estilo_EstiloDMId");
            CreateIndex("dbo.ClasificacionZapatoDMs", "GeneroDM_GeneroDMId");
            AddForeignKey("dbo.ClasificacionZapatoDMs", "GeneroDM_GeneroDMId", "dbo.GeneroDMs", "GeneroDMId");
            AddForeignKey("dbo.SerieZapatosDMs", "Talla_TallaDMId", "dbo.TallaDMs", "TallaDMId");
            AddForeignKey("dbo.SerieZapatosDMs", "Estilo_EstiloDMId", "dbo.EstiloDMs", "EstiloDMId");
        }
    }
}

namespace Back_End.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Zapato_Details_Classes_FK1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClasificacionZapatoDMs",
                c => new
                    {
                        ClasificacionZapatoDMId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        GeneroDM_GeneroDMId = c.Int(nullable: false),
                        PesoEstimadoG = c.Int(),
                    })
                .PrimaryKey(t => t.ClasificacionZapatoDMId);
            
            CreateTable(
                "dbo.ColorDMs",
                c => new
                    {
                        ColorDMId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.ColorDMId);
            
            CreateTable(
                "dbo.EdadDMs",
                c => new
                    {
                        EdadDMId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.EdadDMId);
            
            CreateTable(
                "dbo.EstiloDMs",
                c => new
                    {
                        EstiloDMId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        PrecioCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioVenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImpuestoVenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ganancia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImpuestoCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PorcentajeUtilidad = c.Int(nullable: false),
                        PrecioTotalCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioTotalVenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TieneDescuento = c.Boolean(nullable: false),
                        Descuento = c.Int(),
                        ClasificacionZapatoDMId_ClasificacionZapatoDMId = c.Int(),
                        ColorDM_ColorDMId = c.Int(),
                        EdadDM_EdadDMId = c.Int(),
                        GeneroDM_GeneroDMId = c.Int(),
                    })
                .PrimaryKey(t => t.EstiloDMId)
                .ForeignKey("dbo.ClasificacionZapatoDMs", t => t.ClasificacionZapatoDMId_ClasificacionZapatoDMId)
                .ForeignKey("dbo.ColorDMs", t => t.ColorDM_ColorDMId)
                .ForeignKey("dbo.EdadDMs", t => t.EdadDM_EdadDMId)
                .ForeignKey("dbo.GeneroDMs", t => t.GeneroDM_GeneroDMId)
                .Index(t => t.ClasificacionZapatoDMId_ClasificacionZapatoDMId)
                .Index(t => t.ColorDM_ColorDMId)
                .Index(t => t.EdadDM_EdadDMId)
                .Index(t => t.GeneroDM_GeneroDMId);
            
            CreateTable(
                "dbo.GeneroDMs",
                c => new
                    {
                        GeneroDMId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.GeneroDMId);
            
            CreateTable(
                "dbo.SerieZapatosDMs",
                c => new
                    {
                        SerieZapatosDMId = c.Int(nullable: false, identity: true),
                        CantidadDisponible = c.Int(nullable: false),
                        EstiloDM_EstiloDMId = c.Int(),
                        TallaDM_TallaDMId = c.Int(),
                    })
                .PrimaryKey(t => t.SerieZapatosDMId)
                .ForeignKey("dbo.EstiloDMs", t => t.EstiloDM_EstiloDMId)
                .ForeignKey("dbo.TallaDMs", t => t.TallaDM_TallaDMId)
                .Index(t => t.EstiloDM_EstiloDMId)
                .Index(t => t.TallaDM_TallaDMId);
            
            CreateTable(
                "dbo.TallaDMs",
                c => new
                    {
                        TallaDMId = c.Int(nullable: false, identity: true),
                        NumeroTalla = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TallaDMId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SerieZapatosDMs", "TallaDM_TallaDMId", "dbo.TallaDMs");
            DropForeignKey("dbo.SerieZapatosDMs", "EstiloDM_EstiloDMId", "dbo.EstiloDMs");
            DropForeignKey("dbo.EstiloDMs", "GeneroDM_GeneroDMId", "dbo.GeneroDMs");
            DropForeignKey("dbo.EstiloDMs", "EdadDM_EdadDMId", "dbo.EdadDMs");
            DropForeignKey("dbo.EstiloDMs", "ColorDM_ColorDMId", "dbo.ColorDMs");
            DropForeignKey("dbo.EstiloDMs", "ClasificacionZapatoDMId_ClasificacionZapatoDMId", "dbo.ClasificacionZapatoDMs");
            DropIndex("dbo.SerieZapatosDMs", new[] { "TallaDM_TallaDMId" });
            DropIndex("dbo.SerieZapatosDMs", new[] { "EstiloDM_EstiloDMId" });
            DropIndex("dbo.EstiloDMs", new[] { "GeneroDM_GeneroDMId" });
            DropIndex("dbo.EstiloDMs", new[] { "EdadDM_EdadDMId" });
            DropIndex("dbo.EstiloDMs", new[] { "ColorDM_ColorDMId" });
            DropIndex("dbo.EstiloDMs", new[] { "ClasificacionZapatoDMId_ClasificacionZapatoDMId" });
            DropTable("dbo.TallaDMs");
            DropTable("dbo.SerieZapatosDMs");
            DropTable("dbo.GeneroDMs");
            DropTable("dbo.EstiloDMs");
            DropTable("dbo.EdadDMs");
            DropTable("dbo.ColorDMs");
            DropTable("dbo.ClasificacionZapatoDMs");
        }
    }
}

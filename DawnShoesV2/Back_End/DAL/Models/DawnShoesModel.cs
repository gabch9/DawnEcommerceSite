namespace Back_End.DAL.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DawnShoesModel : DbContext
    {
        // Your context has been configured to use a 'DawnShoesModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Back_End.Models.DawnShoesModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DawnShoesModel' 
        // connection string in the application configuration file.
        public DawnShoesModel()
            : base("name=DawnShoesModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<EstiloDM> EstiloDM { get; set; }
        public DbSet<EdadDM> EdadDM { get; set; }
        public DbSet<ColorDM> ColorDM { get; set; }
        public DbSet<TallaDM> TallaDM { get; set; }
        public DbSet<EstiloDMTallaDM> EstiloDMTallaDM { get; set; }
        public DbSet<GeneroDM> GeneroDM { get; set; }
        public DbSet<ClasificacionZapatoDM> ClasificacionZapatoDM { get; set; }
        public DbSet<ImagenEstiloDM> ImagenEstiloDM { get; set; }
    }
}
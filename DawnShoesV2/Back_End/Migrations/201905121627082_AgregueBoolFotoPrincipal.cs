namespace Back_End.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregueBoolFotoPrincipal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImagenEstiloDMs", "EsPrincipal", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ImagenEstiloDMs", "EsPrincipal");
        }
    }
}

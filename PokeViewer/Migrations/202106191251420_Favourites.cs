namespace PokeViewer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Favourites : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavouritesPokemons",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Owner = c.String(maxLength: 50),
                        PersonalName = c.String(maxLength: 50),
                        PokemonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FavouritesPokemons");
        }
    }
}

namespace PokeViewer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pokemons",
                c => new
                    {
                        PokemonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Height = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        Sprites_BackDefault = c.String(),
                        Sprites_BackShiny = c.String(),
                        Sprites_FrontDefault = c.String(),
                        Sprites_FrontShiny = c.String(),
                    })
                .PrimaryKey(t => t.PokemonId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pokemons");
        }
    }
}

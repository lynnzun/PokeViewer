namespace PokeViewer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpritesRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pokemons", "Sprites_BackDefault");
            DropColumn("dbo.Pokemons", "Sprites_BackShiny");
            DropColumn("dbo.Pokemons", "Sprites_FrontDefault");
            DropColumn("dbo.Pokemons", "Sprites_FrontShiny");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pokemons", "Sprites_FrontShiny", c => c.String());
            AddColumn("dbo.Pokemons", "Sprites_FrontDefault", c => c.String());
            AddColumn("dbo.Pokemons", "Sprites_BackShiny", c => c.String());
            AddColumn("dbo.Pokemons", "Sprites_BackDefault", c => c.String());
        }
    }
}

namespace PokeViewer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pokemons", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pokemons", "Name", c => c.String());
        }
    }
}

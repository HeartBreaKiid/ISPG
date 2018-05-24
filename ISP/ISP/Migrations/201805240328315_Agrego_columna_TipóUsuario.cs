namespace ISP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agrego_columna_TipóUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "TipoUsuario", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "TipoUsuario");
        }
    }
}

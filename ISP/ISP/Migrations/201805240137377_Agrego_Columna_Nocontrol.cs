namespace ISP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agrego_Columna_Nocontrol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nocontrol", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Nocontrol");
        }
    }
}

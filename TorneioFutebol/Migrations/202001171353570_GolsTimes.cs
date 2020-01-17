namespace TorneioFutebol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GolsTimes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jogoes", "GolsTime1", c => c.Int(nullable: false));
            AddColumn("dbo.Jogoes", "GolsTime2", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jogoes", "GolsTime2");
            DropColumn("dbo.Jogoes", "GolsTime1");
        }
    }
}

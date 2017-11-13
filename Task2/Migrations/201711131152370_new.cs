namespace Task2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "length", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "length");
        }
    }
}

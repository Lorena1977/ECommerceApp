namespace ECOMMERCE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class departments : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "Name", c => c.String());
        }
    }
}

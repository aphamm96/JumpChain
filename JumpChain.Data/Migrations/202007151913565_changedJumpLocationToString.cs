namespace JumpChain.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedJumpLocationToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jump", "JumpLocation", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jump", "JumpLocation", c => c.Int(nullable: false));
        }
    }
}

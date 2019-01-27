namespace SignalDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jjkcccss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FromUserId = c.Int(nullable: false),
                        ToUserId = c.Int(nullable: false),
                        Messages = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.FromUserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ToUserId, cascadeDelete: false)
                .Index(t => t.FromUserId)
                .Index(t => t.ToUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "ToUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "FromUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "ToUserId" });
            DropIndex("dbo.Messages", new[] { "FromUserId" });
            DropTable("dbo.Messages");
        }
    }
}

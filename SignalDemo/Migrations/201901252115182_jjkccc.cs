namespace SignalDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jjkccc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId1 = c.Int(nullable: false),
                        UserId2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId1, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId2, cascadeDelete: false)
                .Index(t => t.UserId1)
                .Index(t => t.UserId2);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "UserId2", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "UserId1", "dbo.AspNetUsers");
            DropIndex("dbo.Friends", new[] { "UserId2" });
            DropIndex("dbo.Friends", new[] { "UserId1" });
            DropTable("dbo.Friends");
        }
    }
}

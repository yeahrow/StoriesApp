namespace StoriesApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StoryGroups",
                c => new
                    {
                        StoryId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StoryId, t.GroupId })
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Stories", t => t.StoryId, cascadeDelete: true)
                .Index(t => t.StoryId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        Content = c.String(nullable: false),
                        PostedOn = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Password = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoryGroups", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.Stories", "UserId", "dbo.Users");
            DropForeignKey("dbo.StoryGroups", "GroupId", "dbo.Groups");
            DropIndex("dbo.Users", new[] { "GroupId" });
            DropIndex("dbo.Stories", new[] { "UserId" });
            DropIndex("dbo.StoryGroups", new[] { "GroupId" });
            DropIndex("dbo.StoryGroups", new[] { "StoryId" });
            DropTable("dbo.Users");
            DropTable("dbo.Stories");
            DropTable("dbo.StoryGroups");
            DropTable("dbo.Groups");
        }
    }
}

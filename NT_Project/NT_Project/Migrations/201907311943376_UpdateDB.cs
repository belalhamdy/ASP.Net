namespace NT_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.FriendViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FriendViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        FirstId = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Type = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}

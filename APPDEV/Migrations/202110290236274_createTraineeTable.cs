namespace APPDEV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createTraineeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trainees",
                c => new
                    {
                        TraineeId = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Education = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TraineeId)
                .ForeignKey("dbo.AspNetUsers", t => t.TraineeId)
                .Index(t => t.TraineeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainees", "TraineeId", "dbo.AspNetUsers");
            DropIndex("dbo.Trainees", new[] { "TraineeId" });
            DropTable("dbo.Trainees");
        }
    }
}

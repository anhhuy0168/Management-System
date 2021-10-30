namespace APPDEV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignTrainerToCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignTrainerToCourses",
                c => new
                    {
                        TrainerId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrainerId, t.CourseId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Trainers", t => t.TrainerId, cascadeDelete: true)
                .Index(t => t.TrainerId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignTrainerToCourses", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.AssignTrainerToCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.AssignTrainerToCourses", new[] { "CourseId" });
            DropIndex("dbo.AssignTrainerToCourses", new[] { "TrainerId" });
            DropTable("dbo.AssignTrainerToCourses");
        }
    }
}

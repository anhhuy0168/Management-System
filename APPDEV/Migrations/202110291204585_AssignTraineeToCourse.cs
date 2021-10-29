namespace APPDEV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignTraineeToCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignTraineeToCourses",
                c => new
                    {
                        TraineeId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TraineeId, t.CourseId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Trainees", t => t.TraineeId, cascadeDelete: true)
                .Index(t => t.TraineeId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignTraineeToCourses", "TraineeId", "dbo.Trainees");
            DropForeignKey("dbo.AssignTraineeToCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.AssignTraineeToCourses", new[] { "CourseId" });
            DropIndex("dbo.AssignTraineeToCourses", new[] { "TraineeId" });
            DropTable("dbo.AssignTraineeToCourses");
        }
    }
}

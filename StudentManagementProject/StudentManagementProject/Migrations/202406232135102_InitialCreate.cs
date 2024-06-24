namespace StudentManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        course_id = c.Int(nullable: false, identity: true),
                        course_name = c.String(nullable: false, maxLength: 50),
                        teacher_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.course_id)
                .ForeignKey("dbo.Teachers", t => t.teacher_id, cascadeDelete: true)
                .Index(t => t.teacher_id);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        enrollment_id = c.Int(nullable: false, identity: true),
                        student_id = c.Int(nullable: false),
                        course_id = c.Int(nullable: false),
                        grade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.enrollment_id)
                .ForeignKey("dbo.Courses", t => t.course_id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.student_id, cascadeDelete: true)
                .Index(t => t.student_id)
                .Index(t => t.course_id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        student_id = c.Int(nullable: false, identity: true),
                        student_name = c.String(nullable: false, maxLength: 50),
                        student_surname = c.String(nullable: false, maxLength: 50),
                        email = c.String(),
                        password = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.student_id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        teacher_id = c.Int(nullable: false, identity: true),
                        teacher_name = c.String(nullable: false, maxLength: 50),
                        teacher_surname = c.String(nullable: false, maxLength: 50),
                        email = c.String(),
                        password = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.teacher_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "teacher_id", "dbo.Teachers");
            DropForeignKey("dbo.Enrollments", "student_id", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "course_id", "dbo.Courses");
            DropIndex("dbo.Enrollments", new[] { "course_id" });
            DropIndex("dbo.Enrollments", new[] { "student_id" });
            DropIndex("dbo.Courses", new[] { "teacher_id" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Courses");
        }
    }
}

using Foundation.Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Foundation.Library.Contexts
{
    public interface IWebsiteContext
    {
        DbSet<Header> Headers { get; set; }
        DbSet<Footer> Footers { get; set; }
        DbSet<Notice> Notices { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Advertise> Advertises { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Parents> Parents { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Designation> Designations { get; set; }
        DbSet<AppointmentImage> AppointmentImages { get; set; }
        DbSet<Section> Sections { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Registration> Registrations { get; set; }
        DbSet<AcademicYear> AcademicYears { get; set; }
        DbSet<Subject> Subjects { get; set; }
        DbSet<Applicants> Applicants { get; set; }
        DbSet<Exam> Exams { get; set; }
        DbSet<ExamRules> ExamRules { get; set; }
        DbSet<Grade> Grades { get; set; }
        DbSet<Mark> Marks { get; set; }
    }
}
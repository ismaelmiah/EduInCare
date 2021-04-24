using Foundation.Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Foundation.Library.Contexts
{
    public class WebsiteContext : DbContext, IWebsiteContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public WebsiteContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString, 
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>()
                .HasOne(x => x.Registration)
                .WithOne(x => x.Student)
                .HasForeignKey<Registration>(x => x.StudentId)
                .HasPrincipalKey<Student>(x => x.Id)
                .IsRequired();

            builder.Entity<Parents>()
                .HasOne(x => x.Student)
                .WithOne(x => x.Parents)
                .HasForeignKey<Parents>(x => x.StudentId)
                .HasPrincipalKey<Student>(x=>x.Id)
                .IsRequired();

            builder.Entity<Employee>()
                .HasOne(x => x.Designation)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.DesignationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Section>()
                .HasOne(x => x.Subject)
                .WithMany(x => x.Sections)
                .HasForeignKey(x => x.SubjectId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Section>()
                .HasOne(x => x.Course)
                .WithMany(x => x.Sections)
                .HasForeignKey(x => x.CourseId)
                .HasPrincipalKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Subject>()
                .HasOne(x => x.Course)
                .WithMany(x => x.Subjects)
                .HasForeignKey(x => x.CourseId)
                .HasPrincipalKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Subject>()
                .HasOne(x => x.Course)
                .WithMany(x => x.Subjects)
                .HasForeignKey(x => x.CourseId)
                .HasPrincipalKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Section>()
                .HasOne(x => x.Employee)
                .WithOne(x => x.Section)
                .HasForeignKey<Section>(x => x.TeacherId);

            builder.Entity<Registration>()
                .HasOne(x => x.Section)
                .WithMany(x => x.Registration)
                .HasForeignKey(x => x.SectionId)
                .HasPrincipalKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Course>()
                .HasOne(x => x.Department)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.DepartmentId)
                .HasPrincipalKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Registration>()
                .HasOne(x => x.Course)
                .WithMany(x => x.Registration)
                .HasForeignKey(x => x.CourseId)
                .HasPrincipalKey(x=>x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Registration>()
                .HasOne(x => x.AcademicYear)
                .WithMany(x => x.Registration)
                .HasForeignKey(x => x.AcademicYearId)
                .HasPrincipalKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<Course>()
                .HasOne(x => x.AcademicYear)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.AcademicYearId)
                .HasPrincipalKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Registration>()
                .HasOne(x => x.Student)
                .WithOne(x => x.Registration)
                .HasForeignKey<Registration>(x => x.StudentId);

            builder.Entity<Exam>()
                .HasOne(x => x.Course)
                .WithMany(x => x.Exams)
                .HasForeignKey(x => x.CourseId)
                .HasPrincipalKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Exam>()
                .HasOne(x => x.ExamRules)
                .WithOne(x => x.Exam)
                .HasForeignKey<ExamRules>(x => x.ExamId)
                .IsRequired();

            builder.Entity<ExamRules>()
                .HasOne(x => x.Grade)
                .WithMany(x => x.ExamRules)
                .HasForeignKey(x => x.GradeId)
                .HasPrincipalKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); ;

            builder.Entity<ExamRules>()
                .HasOne(x => x.Course)
                .WithMany(x => x.ExamRules)
                .HasForeignKey(x => x.CourseId)
                .HasPrincipalKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ExamRules>()
                .HasOne(x => x.Subject)
                .WithMany(x => x.ExamRules)
                .HasForeignKey(x => x.SubjectId)
                .HasPrincipalKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Mark>()
                .HasOne(x => x.Student)
                .WithMany(x => x.Marks)
                .HasForeignKey(x => x.StudentId)
                .HasPrincipalKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Mark>()
                .HasOne(x => x.Subject)
                .WithOne(x => x.Mark)
                .HasForeignKey<Mark>(x => x.SubjectId);

            builder.Entity<Mark>()
                .HasOne(x => x.Course)
                .WithMany(x => x.Marks)
                .HasForeignKey(x => x.CourseId)
                .HasPrincipalKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<Mark>()
                .HasOne(x => x.Section)
                .WithMany(x => x.Marks)
                .HasForeignKey(x => x.SectionId)
                .HasPrincipalKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Mark>()
                .HasOne(x => x.AcademicYear)
                .WithMany(x => x.Marks)
                .HasForeignKey(x => x.AcademicYearId)
                .HasPrincipalKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        public DbSet<Header> Headers { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Advertise> Advertises { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Parents> Parents { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<AppointmentImage> AppointmentImages { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Applicants> Applicants { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamRules> ExamRules { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Mark> Marks { get; set; }
    }
}

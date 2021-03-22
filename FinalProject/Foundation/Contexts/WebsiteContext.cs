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
                .HasOne(x => x.Course)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.CourseId)
                .HasPrincipalKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Parents>()
                .HasOne(x => x.Student)
                .WithOne(x => x.Parents)
                .HasForeignKey<Parents>(x => x.StudentId)
                .HasPrincipalKey<Student>(x=>x.Id)
                .IsRequired();

            builder.Entity<Course>()
                .HasOne(x => x.Department)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.DepartmentId)
                .IsRequired();

            builder.Entity<JobInfo>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.JobInfo)
                .HasForeignKey(x => x.EmployeeId)
                .HasPrincipalKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<EmploymentHistory>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.EmploymentHistory)
                .HasForeignKey(x => x.EmployeeId)
                .HasPrincipalKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<EmployeeEducation>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.EmployeeEducation)
                .HasForeignKey(x => x.EmployeeId)
                .HasPrincipalKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<EmployeeEducation>()
                .HasOne(x => x.EducationLevel)
                .WithOne(x => x.EmployeeEducation)
                .HasForeignKey<EmployeeEducation>(x => x.EducationLevelId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<EmployeeEducation>()
                .HasOne(x => x.ExamTitle)
                .WithOne(x => x.EmployeeEducation)
                .HasForeignKey<EmployeeEducation>(x => x.ExamTitleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ExamTitle>()
                .HasOne(x => x.EducationLevel)
                .WithOne(x => x.ExamTitle)
                .HasForeignKey<ExamTitle>(x => x.EducationLevelId);

            builder.Entity<Designation>()
                .HasOne(x => x.JobInfo)
                .WithOne(x => x.Designation)
                .HasForeignKey<JobInfo>(x => x.DesignationId);
            
            builder.Entity<JobInfo>()
                .HasOne(x => x.Appointment)
                .WithOne(x => x.JobInfo)
                .HasForeignKey<AppointmentImage>(x => x.JobInfoId);

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
        public DbSet<EmployeeEducation> EmployeeEducations { get; set; }
        public DbSet<EmploymentHistory> EmploymentHistories { get; set; }
        public DbSet<JobInfo> JobInfos { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<ExamTitle> ExamTitles { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<AppointmentImage> AppointmentImages { get; set; }
    }
}

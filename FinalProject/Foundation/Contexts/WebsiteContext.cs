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

            builder.Entity<Address>()
                .HasOne(x => x.Student)
                .WithOne(x => x.Address)
                .HasForeignKey<Address>(x => x.StudentId);

            builder.Entity<Image>()
                .HasOne(x => x.Student)
                .WithOne(x => x.Image)
                .HasForeignKey<Image>(x => x.StudentId);

            builder.Entity<Header>()
                .HasOne(x => x.Image)
                .WithOne(x => x.Header)
                .HasForeignKey<HeaderImage>(x => x.HeaderId);


            base.OnModelCreating(builder);
        }

        public DbSet<Header> Headers { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Advertise> Advertises { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Parents> Parents { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}

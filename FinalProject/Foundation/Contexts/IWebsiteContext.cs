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
        DbSet<Image> Images { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Address> Address { get; set; }
        DbSet<Parents> Parents { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<HeaderImage> HeaderImage { get; set; }
        DbSet<EmployeeImage> EmployeeImage { get; set; }
    }
}
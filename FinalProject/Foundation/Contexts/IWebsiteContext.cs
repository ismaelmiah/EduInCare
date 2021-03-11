using Foundation.Entities;
using Microsoft.EntityFrameworkCore;

namespace Foundation.Contexts
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
        DbSet<Address> Addresses { get; set; }
        DbSet<StudentParents> Parents { get; set; }
        DbSet<Course> Courses { get; set; }
    }
}
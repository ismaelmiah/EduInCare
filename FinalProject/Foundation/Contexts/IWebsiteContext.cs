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
    }
}
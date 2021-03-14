using DataAccessLayer;
using Foundation.Library.Contexts;
using Foundation.Library.Repositories;

namespace Foundation.Library.UnitOfWorks
{
    public class WebsiteUnitOfWork : UnitOfWork, IWebsiteUnitOfWork
    {
        public WebsiteUnitOfWork(WebsiteContext dbContext,
            IStudentRepository student,
            IHeaderRepository header,
            IFooterRepository footer,
            INoticeRepository notice,
            IAdvertiseRepository advertise,
            IPostRepository post) : base(dbContext)
        {
            Student = student;
            Header = header;
            Footer = footer;
            Notice = notice;
            Advertise = advertise;
            Post = post;
        }

        public IHeaderRepository Header { get; set; }
        public IFooterRepository Footer { get; set; }
        public IPostRepository Post { get; set; }
        public INoticeRepository Notice { get; set; }
        public IAdvertiseRepository Advertise { get; set; }
        public IStudentRepository Student { get; set; }
    }
}
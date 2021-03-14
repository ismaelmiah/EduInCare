using DataAccessLayer;
using Foundation.Library.Contexts;
using Foundation.Library.Repositories;

namespace Foundation.Library.UnitOfWorks
{
    public class WebsiteUnitOfWork : UnitOfWork, IWebsiteUnitOfWork
    {
        public WebsiteUnitOfWork(WebsiteContext dbContext,
            IHeaderRepository header,
            IFooterRepository footer,
            INoticeRepository notice,
            IAdvertiseRepository advertise,
            IPostRepository post) : base(dbContext)
        {
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
    }
}
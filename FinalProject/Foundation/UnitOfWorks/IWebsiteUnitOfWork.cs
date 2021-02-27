using DataAccessLayer;
using Foundation.Repositories;

namespace Foundation.UnitOfWorks
{
    public interface IWebsiteUnitOfWork : IUnitOfWork
    {
        IHeaderRepository Header { get; set; }
        IFooterRepository Footer { get; set; }
        IPostRepository Post { get; set; }
        INoticeRepository Notice { get; set; }
        IAdvertiseRepository Advertise { get; set; }
    }
}
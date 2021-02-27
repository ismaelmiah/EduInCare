using Foundation.UnitOfWorks;

namespace Foundation.Services
{
    public class NoticeService : INoticeService
    {
        private readonly IWebsiteUnitOfWork _websiteUnit;

        public NoticeService(IWebsiteUnitOfWork website)
        {
            _websiteUnit = website;
        }
    }
}
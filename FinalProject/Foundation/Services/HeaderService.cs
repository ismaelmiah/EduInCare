using Foundation.UnitOfWorks;

namespace Foundation.Services
{
    public class HeaderService : IHeaderService
    {

        private readonly IWebsiteUnitOfWork _websiteUnit;

        public HeaderService(IWebsiteUnitOfWork website)
        {
            _websiteUnit = website;
        }
    }
}
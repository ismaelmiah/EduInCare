using Foundation.UnitOfWorks;

namespace Foundation.Services
{
    public class FooterService : IFooterService
    {

        private readonly IWebsiteUnitOfWork _websiteUnit;

        public FooterService(IWebsiteUnitOfWork website)
        {
            _websiteUnit = website;
        }
    }
}
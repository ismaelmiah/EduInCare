using Foundation.UnitOfWorks;

namespace Foundation.Services
{
    public class AdvertiseService : IAdvertiseService
    {

        private readonly IWebsiteUnitOfWork _websiteUnit;

        public AdvertiseService(IWebsiteUnitOfWork website)
        {
            _websiteUnit = website;
        }
    }
}
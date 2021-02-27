using Foundation.Entities;
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

        public void AddHeaderImage(Header header)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveHeaderImage()
        {
            throw new System.NotImplementedException();
        }
    }
}
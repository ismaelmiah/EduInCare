using System.Collections.Generic;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
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
            _websiteUnit.Header.Add(header);
            _websiteUnit.Save();
        }

        public IList<Header> GetHeader()
        {
            return _websiteUnit.Header.Get(null,null, "", false);
        }

        public void RemoveHeaderImage()
        {
            throw new System.NotImplementedException();
        }
    }
}
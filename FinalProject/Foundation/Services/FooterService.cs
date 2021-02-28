using System.Collections.Generic;
using Foundation.Entities;
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

        public void AddFooter(Footer footer)
        {
            _websiteUnit.Footer.Add(footer);
            _websiteUnit.Save();
        }

        public IList<Footer> GetFooter()
        {
            return _websiteUnit.Footer.GetAll();
        }
    }
}
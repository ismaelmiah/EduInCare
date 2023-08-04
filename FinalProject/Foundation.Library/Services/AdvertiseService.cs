using System.Collections.Generic;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class AdvertiseService : IAdvertiseService
    {

        private readonly IWebsiteUnitOfWork _websiteUnit;

        public AdvertiseService(IWebsiteUnitOfWork website)
        {
            _websiteUnit = website;
        }

        public void CreateAdvertise(Advertise advertise)
        {
            _websiteUnit.Advertise.Add(advertise);
            _websiteUnit.Save();
        }

        public IList<Advertise> GetAdvertises()
        {
            return _websiteUnit.Advertise.GetAll();
        }
    }
}
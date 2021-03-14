using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IAdvertiseService
    {
        void CreateAdvertise(Advertise advertise);
        IList<Advertise> GetAdvertises();
    }
}
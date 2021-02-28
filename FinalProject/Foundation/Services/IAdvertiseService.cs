using System.Collections.Generic;
using Foundation.Entities;

namespace Foundation.Services
{
    public interface IAdvertiseService
    {
        void CreateAdvertise(Advertise advertise);
        IList<Advertise> GetAdvertises();
    }
}
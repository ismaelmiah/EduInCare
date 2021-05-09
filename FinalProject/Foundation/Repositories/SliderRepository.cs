using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class SliderRepository : Repository<Sliders, Guid, WebsiteContext>, ISliderRepository
    {
        public SliderRepository(WebsiteContext context) : base(context)
        {
        }
    }
}

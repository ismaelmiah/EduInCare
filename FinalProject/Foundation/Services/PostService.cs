using Foundation.UnitOfWorks;

namespace Foundation.Services
{
    public class PostService : IPostService
    {
        private readonly IWebsiteUnitOfWork _websiteUnit;

        public PostService(IWebsiteUnitOfWork website)
        {
            _websiteUnit = website;
        }
    }
}
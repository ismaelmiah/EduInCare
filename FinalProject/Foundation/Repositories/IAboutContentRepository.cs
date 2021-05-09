using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public interface IAboutContentRepository : IRepository<AboutContent, Guid, WebsiteContext>
    {
        
    }
}
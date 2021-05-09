using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class EventsRepository : Repository<Events, Guid, WebsiteContext>, IEventsRepository
    {
        public EventsRepository(WebsiteContext context) : base(context)
        {
        }
    }
}
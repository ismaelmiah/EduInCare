using System;
using System.Collections.Generic;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class EventService : IBaseService<Events>
    {
        private readonly IWebsiteUnitOfWork _website;

        public EventService(IWebsiteUnitOfWork website)
        {
            _website = website;
        }

        public Events Get(Guid id) => _website.EventsRepository.GetById(id);

        public void Create(Events entity)
        {
            _website.EventsRepository.Add(entity);
            _website.Save();
        }

        public void Update(Events entity)
        {
            _website.EventsRepository.Edit(entity);
            _website.Save();
        }

        public void Delete(Guid id) => _website.EventsRepository.Remove(id);

        public IList<Events> GetList() => _website.EventsRepository.GetAll();

        public (int total, int totalDisplay, IList<Events> records) GetListForDataTable(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using Foundation.Library.BaseServices;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public interface ISliderService : IBaseService<Sliders>
    {

    }
    public class SliderService : ISliderService
    {
        private readonly IWebsiteUnitOfWork _website;

        public SliderService(IWebsiteUnitOfWork website)
        {
            _website = website;
        }

        public Sliders Get(Guid id) => _website.SliderRepository.GetById(id);

        public void Create(Sliders entity)
        {
            _website.SliderRepository.Add(entity);
            _website.Save();
        }

        public void Update(Sliders entity)
        {
            _website.SliderRepository.Edit(entity);
            _website.Save();
        }

        public void Delete(Guid id) => _website.SliderRepository.Remove(id);

        public IList<Sliders> GetList() => _website.SliderRepository.GetAll();

        public (int total, int totalDisplay, IList<Sliders> records) GetListForDataTable(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
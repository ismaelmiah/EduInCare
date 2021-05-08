using System;
using System.Collections.Generic;
using Foundation.Library.BaseServices;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public interface ITestimonialService : IBaseService<Testimonials>
    {

    }
    public class TestimonialService : ITestimonialService
    {
        private readonly IWebsiteUnitOfWork _website;

        public TestimonialService(IWebsiteUnitOfWork website)
        {
            _website = website;
        }

        public Testimonials Get(Guid id) => _website.TestimonialRepository.GetById(id);

        public void Create(Testimonials entity)
        {
            _website.TestimonialRepository.Add(entity);
            _website.Save();
        }

        public void Update(Testimonials entity)
        {
            _website.TestimonialRepository.Edit(entity);
            _website.Save();
        }

        public void Delete(Guid id) => _website.TestimonialRepository.Remove(id);

        public IList<Testimonials> GetList() => _website.TestimonialRepository.GetAll();


        public (int total, int totalDisplay, IList<Testimonials> records) GetListForDataTable(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
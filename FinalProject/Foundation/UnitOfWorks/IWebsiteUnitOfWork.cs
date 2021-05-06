using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;
using Foundation.Library.Repositories;

namespace Foundation.Library.UnitOfWorks
{
    public interface IWebsiteUnitOfWork : IUnitOfWork
    {
        IHeaderRepository Header { get; set; }
        IFooterRepository Footer { get; set; }
        IPostRepository Post { get; set; }
        INoticeRepository Notice { get; set; }
        IAdvertiseRepository Advertise { get; set; }
        IRepository<Sliders, Guid, WebsiteContext> SliderRepository { get; set; }
        IRepository<AboutContent, Guid, WebsiteContext> AboutContentRepository { get; set; }
        IRepository<Testimonials, Guid, WebsiteContext> TestimonialRepository { get; set; }
        IRepository<Events, Guid, WebsiteContext> EventsRepository { get; set; }
        IRepository<ClassProfiles, Guid, WebsiteContext> ClassProfileRepository { get; set; }
        IRepository<TeacherProfiles, Guid, WebsiteContext> TeacherProfileRepository { get; set; }
    }
}
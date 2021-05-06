using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;
using Foundation.Library.Repositories;

namespace Foundation.Library.UnitOfWorks
{
    public class WebsiteUnitOfWork : UnitOfWork, IWebsiteUnitOfWork
    {
        public WebsiteUnitOfWork(WebsiteContext dbContext,
            IHeaderRepository header,
            IFooterRepository footer,
            INoticeRepository notice,
            IAdvertiseRepository advertise,
            IPostRepository post, 
            IRepository<Sliders, Guid, WebsiteContext> sliderRepository,
            IRepository<AboutContent, Guid, WebsiteContext> aboutContentRepository,
            IRepository<Testimonials, Guid, WebsiteContext> testimonialRepository,
            IRepository<Events, Guid, WebsiteContext> eventsRepository,
            IRepository<ClassProfiles, Guid, WebsiteContext> classProfileRepository,
            IRepository<TeacherProfiles, Guid, WebsiteContext> teacherProfileRepository) : base(dbContext)
        {
            Header = header;
            Footer = footer;
            Notice = notice;
            Advertise = advertise;
            Post = post;
            AboutContentRepository = aboutContentRepository;
            TestimonialRepository = testimonialRepository;
            EventsRepository = eventsRepository;
            ClassProfileRepository = classProfileRepository;
            TeacherProfileRepository = teacherProfileRepository;
            SliderRepository = sliderRepository;
        }

        public IHeaderRepository Header { get; set; }
        public IFooterRepository Footer { get; set; }
        public IPostRepository Post { get; set; }
        public INoticeRepository Notice { get; set; }
        public IAdvertiseRepository Advertise { get; set; }
        public IRepository<Sliders, Guid, WebsiteContext> SliderRepository { get; set; }
        public IRepository<AboutContent, Guid, WebsiteContext> AboutContentRepository { get; set; }
        public IRepository<Testimonials, Guid, WebsiteContext> TestimonialRepository { get; set; }
        public IRepository<Events, Guid, WebsiteContext> EventsRepository { get; set; }
        public IRepository<ClassProfiles, Guid, WebsiteContext> ClassProfileRepository { get; set; }
        public IRepository<TeacherProfiles, Guid, WebsiteContext> TeacherProfileRepository { get; set; }
    }
}
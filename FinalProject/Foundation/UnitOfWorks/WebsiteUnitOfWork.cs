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
            ISliderRepository sliderRepository,
            IAboutContentRepository aboutContentRepository,
            ITestimonialRepository testimonialRepository,
            IEventsRepository eventsRepository,
            IClassProfilesRepository classProfileRepository,
            ITeacherProfilesRepository teacherProfileRepository) : base(dbContext)
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
        public ISliderRepository SliderRepository { get; set; }
        public IAboutContentRepository AboutContentRepository { get; set; }
        public ITestimonialRepository TestimonialRepository { get; set; }
        public IEventsRepository EventsRepository { get; set; }
        public IClassProfilesRepository ClassProfileRepository { get; set; }
        public ITeacherProfilesRepository TeacherProfileRepository { get; set; }
    }
}
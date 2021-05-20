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
        ISliderRepository SliderRepository { get; set; }
        IAboutContentRepository AboutContentRepository { get; set; }
        ITestimonialRepository TestimonialRepository { get; set; }
        IEventsRepository EventsRepository { get; set; }
        IClassProfilesRepository ClassProfileRepository { get; set; }
        ITeacherProfilesRepository TeacherProfileRepository { get; set; }
        IFeatureInfoRepository FeatureInfoRepository { get; set; }
        IFacilityRepository FacilityRepository { get; set; }
    }
}
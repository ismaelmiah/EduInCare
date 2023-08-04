using FinalProject.Web.Areas.Admin.Models;

namespace FinalProject.Web.Models
{
    public class WebsiteModel
    {
        public HeaderModel Header { get; set; }
        public FooterModel Footer { get; set; }
        public PostModel Post { get; set; }
        public NoticeModel Notice { get; set; }
        public AdvertiseModel Advertise { get; set; }
    }
}
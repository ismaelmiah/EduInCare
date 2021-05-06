using System;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class AboutContent : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string WhyContent { get; set; }
        public string KeyPoints { get; set; }
        public string AboutUs { get; set; }
        public string WhoWeAre { get; set; }
        public string IntroVideoEmbedCode { get; set; }
        public string MoreVideoLink { get; set; }
    }
}
using System;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class Sliders : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public int Order { get; set; }
    }
}
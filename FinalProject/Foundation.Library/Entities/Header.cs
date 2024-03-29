﻿using System;
using DataAccessLayer;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class Header : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string ImageAlternativeText { get; set; }
        public bool ShowBannerImage { get; set; }
    }
}
﻿using System;
using DataAccessLayer;

namespace Foundation.Entity
{
    public class Advertise : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ActionUrl { get; set; }
    }
}
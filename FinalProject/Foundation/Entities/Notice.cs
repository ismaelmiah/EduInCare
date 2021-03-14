﻿using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class Notice : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
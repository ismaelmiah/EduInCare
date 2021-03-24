﻿using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class Course : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid GroupId { get; set; }
        public virtual Group Group { get; set; }
        public int Duration { get; set; }
        public bool HaveCompulsorySubject { get; set; }
        public int MaxCompulsorySubject { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        //TODO: Course & Department Might be Many TO Many Relationship
        //TODO: Maintain Only One To Many Relations with Dept & Course
    }
}
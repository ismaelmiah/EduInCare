﻿using DataAccessLayer;
using Foundation.Library.Repositories;

namespace Foundation.Library.UnitOfWorks
{
    public interface IManagementUnitOfWork : IUnitOfWork
    {
        public IStudentRepository StudentRepository { get; set; }
        public IParentsRepository ParentsRepository { get; set; }
        public ICourseRepository CourseRepository { get; set; }
    }
}
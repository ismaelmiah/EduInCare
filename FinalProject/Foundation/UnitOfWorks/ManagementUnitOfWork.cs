﻿using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Repositories;

namespace Foundation.Library.UnitOfWorks
{
    public class ManagementUnitOfWork : UnitOfWork, IManagementUnitOfWork
    {
        public ManagementUnitOfWork(WebsiteContext dbContext,
            ICourseRepository course,
            IStudentRepository student,
            IParentsRepository parents,
            IDepartmentRepository department,
            IEmployeeRepository employee,
            IEmployeeEducationRepository education,
            IEducationLevelRepository educationLevel,
            IExamTitleRepository examTitle,
            IEmploymentHistoryRepository employmentHistory) : base(dbContext)
        {
            CourseRepository = course;
            StudentRepository = student;
            ParentsRepository = parents;
            DepartmentRepository = department;
            EmployeeRepository = employee;
            EmployeeEducationRepository = education;
            EducationLevelRepository = educationLevel;
            ExamTitleRepository = examTitle;
            EmploymentHistoryRepository = employmentHistory;
        }

        public IStudentRepository StudentRepository { get; set; }
        public IParentsRepository ParentsRepository { get; set; }
        public ICourseRepository CourseRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IEmployeeEducationRepository EmployeeEducationRepository { get; set; }
        public IEducationLevelRepository EducationLevelRepository { get; set; }
        public IExamTitleRepository ExamTitleRepository { get; set; }
        public IEmploymentHistoryRepository EmploymentHistoryRepository { get; set; }
    }
}
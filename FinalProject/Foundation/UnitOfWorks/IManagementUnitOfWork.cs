using DataAccessLayer;
using DataAccessLayer.Library;
using Foundation.Library.Repositories;

namespace Foundation.Library.UnitOfWorks
{
    public interface IManagementUnitOfWork : IUnitOfWork
    {
        public IStudentRepository StudentRepository { get; set; }
        public IParentsRepository ParentsRepository { get; set; }
        public ICourseRepository CourseRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IEmployeeEducationRepository EmployeeEducationRepository { get; set; }
        public IEducationLevelRepository EducationLevelRepository { get; set; }
        public IExamTitleRepository ExamTitleRepository { get; set; }
        public IEmploymentHistoryRepository EmploymentHistoryRepository { get; set; }
        public IJobInfoRepository JobInfoRepository { get; set; }
        public IDesignationRepository DesignationRepository { get; set; }
        public IGroupRepository GroupRepository { get; set; }
    }
}
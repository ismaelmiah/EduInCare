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
        public IDesignationRepository DesignationRepository { get; set; }
        public IGroupRepository GroupRepository { get; set; }
        public ISectionRepository SectionRepository { get; set; }
        public ISubjectRepository SubjectRepository { get; set; }
        public IAcademicYearRepository AcademicYearRepository { get; set; }
        public IRegistrationStudentRepository RegistrationStudentRepository { get; set; }
        public IApplicantRepository ApplicantRepository { get; set; }
        public IExamRepository ExamRepository { get; set; }
        public IGradeRepository GradeRepository { get; set; }
        public IExamRuleRepository ExamRuleRepository { get; set; }
        public IMarkRepository MarkRepository { get; set; }
        public IResultRepository ResultRepository { get; set; }
        public IStudentAttendanceRepository StudentAttendanceRepository { get; set; }
        public IEmployeeAttendanceRepository EmployeeAttendanceRepository { get; set; }
    }
}
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Repositories;

namespace Foundation.Library.UnitOfWorks
{
    public class ManagementUnitOfWork : UnitOfWork, IManagementUnitOfWork
    {
        private readonly IRegistrationStudentRepository _registrationStudent;

        public ManagementUnitOfWork(WebsiteContext dbContext,
            ICourseRepository course,
            IStudentRepository student,
            IParentsRepository parents,
            IDepartmentRepository department,
            IEmployeeRepository employee,
            IDesignationRepository designation,
            IGroupRepository group,
            ISectionRepository section,
            ISubjectRepository subject,
            IAcademicYearRepository academicYear,
            IRegistrationStudentRepository registrationStudent,
            IApplicantRepository applicant,
            IExamRepository exam,
            IExamRuleRepository examRule,
            IGradeRepository grade) : base(dbContext)
        {
            _registrationStudent = registrationStudent;
            CourseRepository = course;
            StudentRepository = student;
            ParentsRepository = parents;
            DepartmentRepository = department;
            EmployeeRepository = employee;
            DesignationRepository = designation;
            GroupRepository = group;
            SectionRepository = section;
            SubjectRepository = subject;
            AcademicYearRepository = academicYear;
            RegistrationStudentRepository = registrationStudent;
            ApplicantRepository = applicant;
            ExamRepository = exam;
            ExamRuleRepository = examRule;
            GradeRepository = grade;
        }

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
    }
}
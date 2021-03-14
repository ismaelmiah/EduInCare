using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Repositories;

namespace Foundation.Library.UnitOfWorks
{
    public class ManagementUnitOfWork : UnitOfWork, IManagementUnitOfWork
    {
        public ManagementUnitOfWork(WebsiteContext dbContext,
            ICourseRepository course,
            IStudentRepository student,
            IParentsRepository parents) : base(dbContext)
        {
            CourseRepository = course;
            StudentRepository = student;
            ParentsRepository = parents;
        }

        public IStudentRepository StudentRepository { get; set; }
        public IParentsRepository ParentsRepository { get; set; }
        public ICourseRepository CourseRepository { get; set; }
    }
}
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Repositories;

namespace Foundation.Library.UnitOfWorks
{
    public class ManagementUnitOfWork : UnitOfWork, IManagementUnitOfWork
    {
        public ManagementUnitOfWork(WebsiteContext dbContext,
            IStudentRepository student,
            IParentsRepository parents) : base(dbContext)
        {
            Student = student;
            ParentsRepository = parents;
        }

        public IStudentRepository Student { get; set; }
        public IParentsRepository ParentsRepository { get; set; }
    }
}
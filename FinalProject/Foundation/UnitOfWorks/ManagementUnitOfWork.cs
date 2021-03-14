using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Repositories;

namespace Foundation.Library.UnitOfWorks
{
    public class ManagementUnitOfWork : UnitOfWork, IManagementUnitOfWork
    {

        public ManagementUnitOfWork(WebsiteContext dbContext,
            IStudentRepository student) : base(dbContext)
        {
            Student = student;
        }

        public IStudentRepository Student { get; set; }
    }
}
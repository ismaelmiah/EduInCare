using DataAccessLayer;
using Foundation.Library.Repositories;

namespace Foundation.Library.UnitOfWorks
{
    public interface IManagementUnitOfWork : IUnitOfWork
    {
        public IStudentRepository Student { get; set; }
    }
}
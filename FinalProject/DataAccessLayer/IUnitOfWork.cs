using System;

namespace DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
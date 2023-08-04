using System;

namespace DataAccessLayer.Library
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
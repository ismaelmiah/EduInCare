﻿using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Library
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public UnitOfWork(DbContext dbContext) => _dbContext = dbContext;

        public void Dispose() => _dbContext?.Dispose();
        public void Save() => _dbContext?.SaveChanges();
    }
}

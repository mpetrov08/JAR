﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Infrastructure.Repository
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;

        IQueryable<T> AllReadOnly<T>() where T : class;

        Task AddAsync<T>(T entity) where T : class;

        Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class;

        Task<T> GetByIdAsync<T>(object id) where T : class;

        Task DeleteAsync<T>(object id) where T : class;

        Task DeleteCompositeAsync<T>(object[] keyValues) where T : class;

        Task<int> SaveChangesAsync();
    }
}

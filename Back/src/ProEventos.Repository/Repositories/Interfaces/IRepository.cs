using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Repository.Repositories.Interfaces
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(ICollection<T> entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}
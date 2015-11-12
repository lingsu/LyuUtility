using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;

namespace Lyu.Utility.EntityFramework.Extensions
{
    public static class RepositoryExtension
    {
        public static async Task DeleteAsync<TEntity>(this IRepository<TEntity> repository,int id) where TEntity : class, IEntity<int>
        {
            var entity = await repository.GetAsync(id);
            await repository.DeleteAsync(entity);
        }
        public static async Task DeleteAsync<TEntity>(this IRepository<TEntity> repository, IEnumerable<int> id) where TEntity : class, IEntity<int>
        {
            foreach (var i in id)
            {
                await repository.DeleteAsync(i);
            }
        }
        public static async Task DeleteAsync<TEntity, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository, IEnumerable<TPrimaryKey> id) where TEntity : class, IEntity<TPrimaryKey>
        {
            foreach (var i in id)
            {
                await repository.DeleteAsync(i);
            }
        }
        public static async Task DeleteAsync<TEntity, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository, TPrimaryKey id) where TEntity : class, IEntity<TPrimaryKey>
        {
            var entity = await repository.GetAsync(id);
            await repository.DeleteAsync(entity);
        }
    }
}
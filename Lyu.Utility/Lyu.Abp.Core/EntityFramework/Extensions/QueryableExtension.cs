using System.Linq;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Lyu.Core.Domain.Entities;

namespace Lyu.Core.EntityFramework.Extensions
{
    public static class QueryableExtension
    {
        public static IOrderedQueryable<T> OrderByDisplayDescending<T>(this IQueryable<T> source) where T : class, IDisplayOrderable
        {
            return source.OrderByDescending(s => s.DisplayOrder);
        }

        public static IOrderedQueryable<T> OrderByIdDescending<T>(this IQueryable<T> source) where T : class, IEntity<int>
        {
            return source.OrderByDescending(s => s.Id);
        }
        public static IOrderedQueryable<T> ThenyOrderByIdDescending<T>(this IOrderedQueryable<T> source) where T : class ,IEntity<int>
        {
            return source.ThenByDescending(s => s.Id);
        }


    }
}
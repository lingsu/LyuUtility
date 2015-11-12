using System.Linq;
using AutoMapper.QueryableExtensions;

namespace Lyu.Utility.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TDto> To<TDto>(this IQueryable query)
        {
            return query.ProjectTo<TDto>();
        } 
    }
}
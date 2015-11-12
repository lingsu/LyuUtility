using System.Linq;
using AutoMapper.QueryableExtensions;
using Lyu.Utility.Extensions;

namespace Lyu.Utility.Application.Services.Dto.Extensions
{
    public static class QueryResultOutputExtension
    {
        public static QueryResultOutput<TDto> ToOutputAsync<TDto>(this IQueryable query, QueryRequestInput option)
        {
            var result = query.To<TDto>();
            var recordsTotal = result.Count();
            return new QueryResultOutput<TDto>()
            {
                Data = result.Skip(option.Start).Take(option.Length).ToList(),
                Draw = option.Draw,
                RecordsTotal = recordsTotal,
                RecordsFiltered = recordsTotal
            };
        }

    }
}
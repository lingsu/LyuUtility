using System.Collections.Generic;

namespace Lyu.Core.Application.Services.Dto.Extensions
{
    public static class QueryResultOutputExtension
    {
        //public static async Task<QueryResultOutput<TDto>> ToOutputAsync<TDto>(this IQueryable query, QueryRequestInput option)
        //{
        //    var result = query.ProjectTo<TDto>();
        //    var recordsTotal = await result.CountAsync();
        //    if (option.Length == -1)
        //    {
        //        option.Length = 100;
        //    }

        //    return new QueryResultOutput<TDto>()
        //    {
        //        Data = await result.Skip(option.Start).Take(option.Length).ToListAsync(),
        //        Draw = option.Draw,
        //        RecordsTotal = recordsTotal,
        //        RecordsFiltered = recordsTotal
        //    };
        //}

        public static QueryResultOutput<TDto> ToStaticOutput<TEntity, TDto>(this QueryResultOutput<TEntity> queryResult,IEnumerable<TDto> list)
        {
            return new QueryResultOutput<TDto>()
            {
                Data = list,
                Draw = queryResult.Draw,
                Error = queryResult.Error,
                RecordsFiltered = queryResult.RecordsFiltered,
                RecordsTotal = queryResult.RecordsTotal
            };
        } 

    }
}
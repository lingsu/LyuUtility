using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Lyu.Utility.Extensions;

namespace Lyu.Utility.Application.Services.Dto.Extensions
{
    public static class QueryResultOutputExtension
    {
        public static async Task<QueryResultOutput<TDto>> ToOutputAsync<TDto>(this IQueryable query, QueryRequestInput option)
        {
            var result = query.To<TDto>();
            var recordsTotal = result.Count();
            return new QueryResultOutput<TDto>()
            {
                Data = await result.Skip(option.Start).Take(option.Length).ToListAsync(),
                Draw = option.Draw,
                RecordsTotal = recordsTotal,
                RecordsFiltered = recordsTotal
            };
        }

    }
}
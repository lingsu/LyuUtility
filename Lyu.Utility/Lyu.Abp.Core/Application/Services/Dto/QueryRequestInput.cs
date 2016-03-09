namespace Lyu.Utility.Application.Services.Dto
{
    public class QueryRequestInput
    {
        public QueryRequestInput()
        {
            Search = new Search();
        }

        /// <summary>
        /// 请求次数计数器，每次发送给服务器后又原封返回，因为请求是异步的为了确保每次请求能对应到服务器返回的数据，假设你请求的是第一页的数据收到的却是第二页的，这样就乱套了 
        /// </summary>
        public int Draw { get; set; }
        /// <summary>
        /// 第一条数据的起始位置，比如0代表第一条数据
        /// </summary>
        public int Start { get; set; }
        /// <summary>
        /// 告诉服务器每页显示的条数，这个数字会等于返回的记录数，可能会大于因为服务器可能没有那么多数据。这个也可能是-1，代表需要返回全部数据(尽管这个和服务器处理的理念有点违背)
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// 搜索条件
        /// </summary>
        public Search Search { get; set; }
    }

    public class Search
    {
        public string Value { get; set; }
    }
}
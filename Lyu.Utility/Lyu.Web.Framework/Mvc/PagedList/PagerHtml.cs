using System;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Lyu.Core.Application.PagedList;

namespace Lyu.Web.Framework.Mvc.PagedList
{
    /// <summary>
    /// 
    /// </summary>
    public static class PagerHtml
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="pagedList"></param>
        /// <param name="pagerOptions"></param>
        /// <returns></returns>
        public static MvcHtmlString Pager(this HtmlHelper helper, IPagedList pagedList, PagedListRenderOptions pagerOptions)
        {
           
            return Pager(helper, pagedList.TotalItemCount, pagedList.PageSize, pagedList.PageNumber, pagerOptions);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="pagedList"></param>
        /// <returns></returns>
        public static MvcHtmlString Pager(this HtmlHelper helper, IPagedList pagedList)
        {

            return Pager(helper, pagedList.TotalItemCount, pagedList.PageSize, pagedList.PageNumber, PagedListRenderOptions.Classic);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="totalItemCount"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pagerOptions"></param>
        /// <returns></returns>
        public static MvcHtmlString Pager(this HtmlHelper helper, int totalItemCount, int pageSize, int pageIndex, PagedListRenderOptions pagerOptions)
        {
            var totalPageCount = (int)Math.Ceiling(totalItemCount / (double)pageSize);

            return new MvcHtmlString(new PagerBuilder
                (
                    helper,
                    totalPageCount,
                    pageIndex,
                    pagerOptions
                ).GenerateHtml());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="pagedList"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MvcHtmlString Pager(this AjaxHelper helper, IPagedList pagedList,string id)
        {

            return Pager(helper, pagedList.TotalItemCount, pagedList.PageSize, pagedList.PageNumber, PagedListRenderOptions.Classic, new AjaxOptions()
            {
                HttpMethod = "GET",
                InsertionMode = InsertionMode.Replace,
                UpdateTargetId = id
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="pagedList"></param>
        /// <param name="pagerOptions"></param>
        /// <param name="ajaxOptions"></param>
        /// <returns></returns>
        public static MvcHtmlString Pager(this AjaxHelper helper, IPagedList pagedList, PagedListRenderOptions pagerOptions, AjaxOptions ajaxOptions)
        {

            return Pager(helper, pagedList.TotalItemCount, pagedList.PageSize, pagedList.PageNumber, pagerOptions, ajaxOptions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="totalItemCount"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pagerOptions"></param>
        /// <param name="ajaxOptions"></param>
        /// <returns></returns>
        public static MvcHtmlString Pager(this AjaxHelper helper, int totalItemCount, int pageSize, int pageIndex, PagedListRenderOptions pagerOptions, AjaxOptions ajaxOptions)
        {
            var totalPageCount = (int)Math.Ceiling(totalItemCount / (double)pageSize);

            return new MvcHtmlString(new PagerBuilder
                (
                    helper,
                    totalPageCount,
                    pageIndex,
                    pagerOptions,
                    ajaxOptions
                ).GenerateHtml());
        }
    }
}
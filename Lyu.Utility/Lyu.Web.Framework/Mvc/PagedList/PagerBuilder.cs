using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;

namespace Lyu.Web.Framework.Mvc.PagedList
{
    /// <summary>
    /// 
    /// </summary>
    public class PagerBuilder
    {
        private HtmlHelper _html;
        private readonly AjaxHelper _ajax;
        private bool _ajaxPagingEnabled;
        private int _totalPageCount;
        private int _pageIndex;
        private PagedListRenderOptions _pagerOptions;
        private int _startPageIndex;
        private int _endPageIndex;
        private RouteValueDictionary _routeValues;
        private ViewContext _viewContext;
        private RouteCollection _routes;
        private readonly AjaxOptions _ajaxOptions;

        internal PagerBuilder(HtmlHelper htmlHelper, int totalPageCount, int pageIndex, PagedListRenderOptions pagerOptions)
        {
            _ajaxPagingEnabled = false;
           
            if (pagerOptions == null)
                pagerOptions = new PagedListRenderOptions();

            _html = htmlHelper;
            _totalPageCount = totalPageCount;
            _pageIndex = pageIndex;
            _pagerOptions = pagerOptions;

            // start page index
            _startPageIndex = pageIndex - (pagerOptions.MaximumPageNumbersToDisplay / 2);
            if (_startPageIndex + pagerOptions.MaximumPageNumbersToDisplay > _totalPageCount)
                _startPageIndex = _totalPageCount + 1 - pagerOptions.MaximumPageNumbersToDisplay;
            if (_startPageIndex < 1)
                _startPageIndex = 1;

            // end page index
            _endPageIndex = _startPageIndex + _pagerOptions.MaximumPageNumbersToDisplay - 1;
            if (_endPageIndex > _totalPageCount)
                _endPageIndex = _totalPageCount;

            _viewContext = _ajax == null ? _html.ViewContext : _ajax.ViewContext;
            _routeValues = new RouteValueDictionary(_viewContext.RouteData.Values);
            AddQueryStringToRouteValues(_routeValues, htmlHelper.ViewContext);

            _routes = _ajax == null ? (_html == null ? RouteTable.Routes : _html.RouteCollection) : _ajax.RouteCollection;

        }
        internal PagerBuilder(AjaxHelper htmlHelper, int totalPageCount, int pageIndex, PagedListRenderOptions pagerOptions, AjaxOptions ajaxOptions)
        {
            _ajaxPagingEnabled = true;
            
            if (pagerOptions == null)
                pagerOptions = new PagedListRenderOptions();

            _ajax = htmlHelper;
            _totalPageCount = totalPageCount;
            _ajaxOptions = ajaxOptions;
            _pageIndex = pageIndex;
            _pagerOptions = pagerOptions;

            // start page index
            _startPageIndex = pageIndex - (pagerOptions.MaximumPageNumbersToDisplay / 2);
            if (_startPageIndex + pagerOptions.MaximumPageNumbersToDisplay > _totalPageCount)
                _startPageIndex = _totalPageCount + 1 - pagerOptions.MaximumPageNumbersToDisplay;
            if (_startPageIndex < 1)
                _startPageIndex = 1;

            // end page index
            _endPageIndex = _startPageIndex + _pagerOptions.MaximumPageNumbersToDisplay - 1;
            if (_endPageIndex > _totalPageCount)
                _endPageIndex = _totalPageCount;

            _viewContext = _ajax == null ? _html.ViewContext : _ajax.ViewContext;
            _routeValues = new RouteValueDictionary(_viewContext.RouteData.Values);
            AddQueryStringToRouteValues(_routeValues, htmlHelper.ViewContext);

            _routes = _ajax == null ? (_html == null ? RouteTable.Routes : _html.RouteCollection) : _ajax.RouteCollection;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GenerateHtml()
        {
            if (_pagerOptions.Display == PagedListDisplayMode.Never || (_pagerOptions.Display == PagedListDisplayMode.IfNeeded && _totalPageCount <= 1))
                return null;

            var tb = new TagBuilder(_pagerOptions.ContainerTagName);
            if (!string.IsNullOrEmpty(_pagerOptions.UlElementClasses))
                tb.AddCssClass(_pagerOptions.UlElementClasses);

            var pagerItems = new List<PagerItem>();

            //First(pagerItems);
            //previous
            Previous(pagerItems);

            AddPageNumbers(pagerItems);

            AddNext(pagerItems);
            //AddLast(pagerItems);

            var sb = new StringBuilder();
            if (_ajaxPagingEnabled)
            {
                foreach (PagerItem item in pagerItems)
                {
                    sb.Append(GenerateAjaxPagerElement(item));
                }
            }
            else
            {
                foreach (PagerItem item in pagerItems)
                {
                    sb.Append(GeneratePagerElement(item));
                }
            }
            tb.InnerHtml = sb.ToString();

            return tb.ToString();
        }

        private void AddPageNumbers(List<PagerItem> pagerItems)
        {
            for (var pageIndex = _startPageIndex; pageIndex <= _endPageIndex; pageIndex++)
            {
                var text = pageIndex.ToString();
                if (pageIndex == _pageIndex && !string.IsNullOrEmpty(_pagerOptions.CurrentPageNumberFormatString))
                    text = String.Format(_pagerOptions.CurrentPageNumberFormatString, text);
                else if (!string.IsNullOrEmpty(_pagerOptions.PageNumberFormatString))
                    text = String.Format(_pagerOptions.PageNumberFormatString, text);
                var item = new PagerItem(text, pageIndex, false, PagerItemType.NumericPage);
                pagerItems.Add(item);
            }
        }

        private void AddLast(List<PagerItem> pagerItems)
        {
            if (_pagerOptions.DisplayLinkToLastPage == PagedListDisplayMode.Always ||
                (_pagerOptions.DisplayLinkToLastPage == PagedListDisplayMode.IfNeeded && _pageIndex >= _totalPageCount))
            {
                var item = new PagerItem(_pagerOptions.LastPageText, _totalPageCount, true, PagerItemType.LastPage);
                pagerItems.Add(item);
            }
        }

        private void AddNext(List<PagerItem> pagerItems)
        {
            if (_pagerOptions.DisplayLinkToNextPage == PagedListDisplayMode.Always ||
                (_pagerOptions.DisplayLinkToNextPage == PagedListDisplayMode.IfNeeded && !(_pageIndex >= _totalPageCount)))
            {
                var item = new PagerItem(_pagerOptions.NextPageText, _pageIndex + 1, true, PagerItemType.NextPage);
                pagerItems.Add(item);
            }
        }

        private void Previous(List<PagerItem> pagerItems)
        {
            if (_pagerOptions.DisplayLinkToPreviousPage == PagedListDisplayMode.Always ||
                (_pagerOptions.DisplayLinkToPreviousPage == PagedListDisplayMode.IfNeeded && _pageIndex > 1))
            {
                var item = new PagerItem(_pagerOptions.PrevPageText, _pageIndex - 1, _pageIndex == 1, PagerItemType.PrevPage);
                pagerItems.Add(item);
            }
        }

        private void First(ICollection<PagerItem> results)
        {
            if (_pagerOptions.DisplayLinkToFirstPage == PagedListDisplayMode.Always ||
                (_pagerOptions.DisplayLinkToFirstPage == PagedListDisplayMode.IfNeeded && _startPageIndex > 1))

            {
                var item = new PagerItem(_pagerOptions.FirstPageText, 1, true, PagerItemType.FirstPage);
                results.Add(item);
            }
        }

        private string GenerateUrl(int pageIndex)
        {
            string routeName = _pagerOptions.RouteName;

            if (pageIndex == 1)
            {
                _routeValues.Remove(_pagerOptions.PageIndexParameterName);
                _viewContext.RouteData.Values.Remove(_pagerOptions.PageIndexParameterName);
            }
            else
            {
                _routeValues[_pagerOptions.PageIndexParameterName] = pageIndex;
            }
            string url;
            if (!string.IsNullOrEmpty(routeName))
                url = UrlHelper.GenerateUrl(routeName, _pagerOptions.ActionName, _pagerOptions.ControllerName, _routeValues, _routes,
                    _viewContext.RequestContext, false);
            else
                url = UrlHelper.GenerateUrl(null, _pagerOptions.ActionName, _pagerOptions.ControllerName, _routeValues, _routes,
                    _viewContext.RequestContext, false);

            return url;
        }


        private IHtmlString GeneratePagerElement(PagerItem item)
        {
            string url = GenerateUrl(item.PageIndex);
            return CreateWrappedPagerElement(item,
                                             string.IsNullOrEmpty(url)
                                                 ? HttpUtility.HtmlEncode(item.Text)
                                                 : String.Format("<a href=\"{0}\">{1}</a>", url, item.Text));
        }

        private IHtmlString GenerateAjaxPagerElement(PagerItem item)
        {
            return CreateWrappedPagerElement(item, GenerateAjaxAnchor(item));
        }

        private string GenerateAjaxAnchor(PagerItem item)
        {
            string url = GenerateUrl(item.PageIndex);
            if (string.IsNullOrWhiteSpace(url))
                return HttpUtility.HtmlEncode(item.Text);
            var tag = new TagBuilder("a") {InnerHtml = item.Text};
            tag.MergeAttribute("href", url);

            foreach (var ajaxOption in _ajaxOptions.ToUnobtrusiveHtmlAttributes())
                tag.Attributes.Add(ajaxOption.Key, ajaxOption.Value.ToString());

            return tag.ToString(TagRenderMode.Normal);
        }
        private IHtmlString CreateWrappedPagerElement(PagerItem item, string el)
        {
            string navStr;
            if (item.PageIndex == _pageIndex)
            {
                navStr = string.Format(_pagerOptions.CurrentPagerItemTemplate, el);
            }
            else 
            {
                navStr = string.Format(_pagerOptions.PagerItemTemplate, el);
            }
           
            return MvcHtmlString.Create(navStr);
        }


        private void AddQueryStringToRouteValues(RouteValueDictionary routeValues, ViewContext viewContext)
        {
            if (routeValues == null)
                routeValues = new RouteValueDictionary();
            var rq = viewContext.HttpContext.Request.QueryString;
            if (rq != null && rq.Count > 0)
            {
                var invalidParams = new[] { "x-requested-with", "xmlhttprequest", _pagerOptions.PageIndexParameterName.ToLower() };
                foreach (string key in rq.Keys)
                {
                    //Add url parameter to route values
                    if (!string.IsNullOrEmpty(key) && Array.IndexOf(invalidParams, key.ToLower()) < 0)
                    {
                        var kv = rq[key];
                        routeValues[key] = kv;
                    }
                }
            }
        }
    }
}
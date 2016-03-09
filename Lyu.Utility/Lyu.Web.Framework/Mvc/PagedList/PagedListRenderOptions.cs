using System.Web.Mvc;

namespace Lyu.Web.Framework.Mvc.PagedList
{
    ///<summary>
    /// Options for configuring the output of <see cref = "HtmlHelper" />.
    ///</summary>
    public class PagedListRenderOptions
    {
        ///<summary>
        /// The default settings render all navigation links and no descriptive text.
        ///</summary>
        public PagedListRenderOptions()
        {
            PageIndexParameterName = "page";
            ContainerTagName = "ul";
            DisplayLinkToFirstPage = PagedListDisplayMode.Never;
            DisplayLinkToLastPage = PagedListDisplayMode.Never;
            DisplayLinkToPreviousPage = PagedListDisplayMode.IfNeeded;
            DisplayLinkToNextPage = PagedListDisplayMode.IfNeeded;
            FirstPageText = "首页";
            PrevPageText = "上一页";
            NextPageText = "下一页";
            LastPageText = "尾页";
            Display = PagedListDisplayMode.IfNeeded;
            PagerItemTemplate = "<li>{0}</li>";
            CurrentPagerItemTemplate = "<li class='active'>{0}</li>";
            ClassToApplyToFirstListItemInPager = null;
            ClassToApplyToLastListItemInPager = null;
            //UlElementClasses = "pagination";
            MaximumPageNumbersToDisplay = 10;
        }

        ///<summary>
        /// CSS Classes to append to the &lt;div&gt; element that wraps the paging control.
        ///</summary>

        /// <summary>
        /// 
        /// </summary>
        public string PageIndexParameterName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ActionName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ControllerName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContainerTagName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FirstPageText { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PrevPageText { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NextPageText { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LastPageText { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CurrentPageNumberFormatString { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PageNumberFormatString { get; set; }
        ///<summary>
        /// The pre-formatted text to display inside the hyperlink to each individual page. The one-based index of the page is passed into the formatting function - use {0} to reference it.
        ///</summary>
        ///<example>
        /// "{0}"
        ///</example>
        public string PagerItemTemplate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CurrentPagerItemTemplate { get; set; }

        ///<summary>
        /// CSSClasses to append to the &lt;ul&gt; element in the paging control.
        ///</summary>
        public string UlElementClasses { get; set; }

        ///<summary>
        /// Specifies a CSS class to append to the first list item in the pager. If null or whitespace is defined, no additional class is added to first list item in list.
        ///</summary>
        public string ClassToApplyToFirstListItemInPager { get; set; }

        ///<summary>
        /// Specifies a CSS class to append to the last list item in the pager. If null or whitespace is defined, no additional class is added to last list item in list.
        ///</summary>
        public string ClassToApplyToLastListItemInPager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int MaximumPageNumbersToDisplay { get; set; }

        /// <summary>
        /// If set to Always, always renders the paging control. If set to IfNeeded, render the paging control when there is more than one page.
        /// </summary>
        public PagedListDisplayMode Display { get; set; }

        ///<summary>
        /// If set to Always, render a hyperlink to the first page in the list. If set to IfNeeded, render the hyperlink only when the first page isn't visible in the paging control.
        ///</summary>
        public PagedListDisplayMode DisplayLinkToFirstPage { get; set; }

        ///<summary>
        /// If set to Always, render a hyperlink to the last page in the list. If set to IfNeeded, render the hyperlink only when the last page isn't visible in the paging control.
        ///</summary>
        public PagedListDisplayMode DisplayLinkToLastPage { get; set; }

        ///<summary>
        /// If set to Always, render a hyperlink to the previous page of the list. If set to IfNeeded, render the hyperlink only when there is a previous page in the list.
        ///</summary>
        public PagedListDisplayMode DisplayLinkToPreviousPage { get; set; }

        ///<summary>
        /// If set to Always, render a hyperlink to the next page of the list. If set to IfNeeded, render the hyperlink only when there is a next page in the list.
        ///</summary>
        public PagedListDisplayMode DisplayLinkToNextPage { get; set; }


        ///// <summary>
        ///// Enables ASP.NET MVC's unobtrusive AJAX feature. An XHR request will retrieve HTML from the clicked page and replace the innerHtml of the provided element ID.
        ///// </summary>
        ///// <param name="options">The preferred Html.PagedList(...) style options.</param>
        ///// <param name="ajaxOptions">The ajax options that will put into the link</param>
        ///// <returns>The PagedListRenderOptions value passed in, with unobtrusive AJAX attributes added to the page links.</returns>
        //public static PagedListRenderOptions EnableUnobtrusiveAjaxReplacing(PagedListRenderOptions options, AjaxOptions ajaxOptions)
        //{
        //    options.FunctionToTransformEachPageLink = (liTagBuilder, aTagBuilder) =>
        //    {
        //        var liClass = liTagBuilder.Attributes.ContainsKey("class") ? liTagBuilder.Attributes["class"] ?? "" : "";
        //        if (ajaxOptions != null && !liClass.Contains("disabled") && !liClass.Contains("active"))
        //        {
        //            foreach (var ajaxOption in ajaxOptions.ToUnobtrusiveHtmlAttributes())
        //                aTagBuilder.Attributes.Add(ajaxOption.Key, ajaxOption.Value.ToString());
        //        }

        //        liTagBuilder.InnerHtml = aTagBuilder.ToString();
        //        return liTagBuilder;
        //    };
        //    return options;
        //}

        ///// <summary>
        ///// Enables ASP.NET MVC's unobtrusive AJAX feature. An XHR request will retrieve HTML from the clicked page and replace the innerHtml of the provided element ID.
        ///// </summary>
        ///// <param name="id">The element ID ("my_id") of the element whose innerHtml should be replaced, if # is included at the start this will be removed.</param>
        ///// <returns>A default instance of PagedListRenderOptions value passed in, with unobtrusive AJAX attributes added to the page links.</returns>
        //public static PagedListRenderOptions EnableUnobtrusiveAjaxReplacing(string id)
        //{

        //    if (id.StartsWith("#"))
        //        id = id.Substring(1);

        //    var ajaxOptions = new AjaxOptions()
        //    {
        //        HttpMethod = "GET",
        //        InsertionMode = InsertionMode.Replace,
        //        UpdateTargetId = id
        //    };

        //    return EnableUnobtrusiveAjaxReplacing(new PagedListRenderOptions(), ajaxOptions);
        //}

        ///// <summary>
        ///// Enables ASP.NET MVC's unobtrusive AJAX feature. An XHR request will retrieve HTML from the clicked page and replace the innerHtml of the provided element ID.
        ///// </summary>
        ///// <param name="ajaxOptions">Ajax options that will be used to generate the unobstrusive tags on the link</param>
        ///// <returns>A default instance of PagedListRenderOptions value passed in, with unobtrusive AJAX attributes added to the page links.</returns>
        //public static PagedListRenderOptions EnableUnobtrusiveAjaxReplacing(AjaxOptions ajaxOptions)
        //{
        //    return EnableUnobtrusiveAjaxReplacing(new PagedListRenderOptions(), ajaxOptions);
        //}

        ///<summary>
        /// Also includes links to First and Last pages.
        ///</summary>
        public static PagedListRenderOptions Classic
        {
            get
            {
                return new PagedListRenderOptions
                {
                    DisplayLinkToFirstPage = PagedListDisplayMode.Never,
                    DisplayLinkToLastPage = PagedListDisplayMode.Never,
                    DisplayLinkToPreviousPage = PagedListDisplayMode.IfNeeded,
                    DisplayLinkToNextPage = PagedListDisplayMode.IfNeeded,
                    Display = PagedListDisplayMode.IfNeeded
                };
            }
        }

    }
}
using System;
using System.Web;
using System.Web.Routing;
using Lyu.Core;

namespace Lyu.Web.Framework.Mvc.Seo
{
    public class GenericPathRoute : Route
    {
        public GenericPathRoute(string url, IRouteHandler routeHandler) : base(url, routeHandler)
        {
        }

        public GenericPathRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler) : base(url, defaults, routeHandler)
        {
        }

        public GenericPathRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler) : base(url, defaults, constraints, routeHandler)
        {
        }

        public GenericPathRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler) : base(url, defaults, constraints, dataTokens, routeHandler)
        {
        }

        #region Methods

        /// <summary>
        /// Returns information about the requested route.
        /// </summary>
        /// <param name="httpContext">An object that encapsulates information about the HTTP request.</param>
        /// <returns>
        /// An object that contains the values from the route definition.
        /// </returns>
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            RouteData data = base.GetRouteData(httpContext);
            if (data != null)
            {
                //data.Values["controller"] = "News";
                //data.Values["action"] = "Detail";
                //data.Values["productid"] = urlRecord.EntityId;
               // data.Values["SeName"] = urlRecord.Slug;

            }
            return data;
        }

        #endregion
    }
}
using System.Web;
using System.Web.Mvc;

namespace Lyu.Web.Framework.Mvc.Authorization
{
    /// <summary>
    /// 跳转到微信登陆
    /// </summary>
    public class WeChatAuthorizeAttribute: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.User.Identity.IsAuthenticated;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("/Account/ExternalLogin?provider=WeChat&returnUrl=" + filterContext.HttpContext.Request.RawUrl);
            }
        }
    }
}
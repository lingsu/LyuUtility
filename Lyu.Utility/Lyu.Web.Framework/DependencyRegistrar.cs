using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Lyu.Abp.Core;

namespace Lyu.Web.Framework
{
    public class DependencyRegistrar : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<HttpContextBase>()
                  .LifeStyle.PerWebRequest
                  .UsingFactoryMethod(() => new HttpContextWrapper(HttpContext.Current)));

            container.Register(Component.For<HttpRequestBase>()
                  .LifeStyle.PerWebRequest
                  .UsingFactoryMethod(kernel => kernel.Resolve<HttpContextBase>().Request));

            container.Register(Component.For<HttpResponseBase>()
                 .LifeStyle.PerWebRequest
                 .UsingFactoryMethod(kernel => kernel.Resolve<HttpContextBase>().Response));

            container.Register(Component.For<HttpServerUtilityBase>()
                  .LifeStyle.PerWebRequest
                  .UsingFactoryMethod(kernel => kernel.Resolve<HttpContextBase>().Server));

            container.Register(Component.For<HttpSessionStateBase>()
                  .LifeStyle.PerWebRequest
                  .UsingFactoryMethod(kernel => kernel.Resolve<HttpContextBase>().Session));

            container.Register(Component.For<HttpApplicationStateBase>()
                  .LifeStyle.PerWebRequest
                  .UsingFactoryMethod(kernel => kernel.Resolve<HttpContextBase>().Application));


            container.Register(Component.For<HttpBrowserCapabilitiesBase>()
                             .LifeStyle.PerWebRequest
                             .UsingFactoryMethod(kernel => kernel.Resolve<HttpRequestBase>().Browser));

            container.Register(Component.For<HttpFileCollectionBase>()
                             .LifeStyle.PerWebRequest
                             .UsingFactoryMethod(kernel => kernel.Resolve<HttpRequestBase>().Files));

            container.Register(Component.For<RequestContext>()
                             .LifeStyle.PerWebRequest
                             .UsingFactoryMethod(kernel => kernel.Resolve<HttpRequestBase>().RequestContext));


            container.Register(Component.For<HttpCachePolicyBase>()
                             .LifeStyle.PerWebRequest
                             .UsingFactoryMethod(kernel => kernel.Resolve<HttpResponseBase>().Cache));

            container.Register(Component.For<VirtualPathProvider>()
                                        .LifeStyle.PerWebRequest
                                        .UsingFactoryMethod(kernel => HostingEnvironment.VirtualPathProvider));

            container.Register(Component.For<UrlHelper>()
                .LifeStyle.PerWebRequest
                .UsingFactoryMethod(kernel => new UrlHelper(kernel.Resolve<RequestContext>())));


            container.Register(Component.For<IWebHelper>().ImplementedBy<WebHelper>()
                  .LifeStyle.PerWebRequest
                  );
        }
    }
}
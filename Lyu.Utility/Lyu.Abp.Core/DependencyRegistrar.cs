using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Lyu.Abp.Core
{
    public class DependencyRegistrar: IWindsorInstaller
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

            container.Register(Component.For<IWebHelper>().ImplementedBy<WebHelper>()
                  .LifeStyle.PerWebRequest
                  );
        }
    }
}
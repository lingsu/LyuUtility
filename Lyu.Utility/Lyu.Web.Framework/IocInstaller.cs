using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Lyu.Web.Framework.UI;

namespace Lyu.Web.Framework
{
    public class IocInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IPageHeadBuilder>().ImplementedBy<PageHeadBuilder>().LifestylePerWebRequest());
        }
    }
}
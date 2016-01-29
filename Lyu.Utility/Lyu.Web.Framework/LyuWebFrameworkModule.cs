using System.Reflection;
using Abp;
using Abp.Modules;

namespace Lyu.Web.Framework
{
    [DependsOn(typeof(AbpKernelModule))]
    public class LyuWebFrameworkModule : AbpModule
    {
        public override void PreInitialize()
        {
           
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

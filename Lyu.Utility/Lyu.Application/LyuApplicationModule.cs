using System.Reflection;
using Abp;
using Abp.Modules;
using Lyu.Application.Messages;

namespace Lyu.Application
{
    [DependsOn(typeof(AbpKernelModule))]
    public class LyuApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Settings.Providers.Add<MessageTemplatesSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

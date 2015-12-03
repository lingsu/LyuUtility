using System.Reflection;
using Abp;
using Abp.Modules;
using Lyu.Abp.Core.Messages;

namespace Lyu.Abp.Core
{
    [DependsOn(typeof(AbpKernelModule))]
    public class LyuAbpCoreModule : AbpModule
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

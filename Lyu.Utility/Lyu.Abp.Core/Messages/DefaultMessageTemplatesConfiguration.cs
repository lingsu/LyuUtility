using Abp.Configuration;
using Abp.Dependency;

namespace Lyu.Abp.Core.Messages
{
    public class DefaultMessageTemplatesConfiguration: IMessageTemplatesSettings, ITransientDependency
    {
        protected readonly ISettingManager SettingManager;

        public DefaultMessageTemplatesConfiguration(ISettingManager settingManager)
        {
            SettingManager = settingManager;
        }


        public bool CaseInvariantReplacement
        {
            get { return SettingManager.GetSettingValue<bool>(MessageTemplatesSettingNames.CaseInvariantReplacement); }
        }

        public string Color1 { get { return SettingManager.GetSettingValue(MessageTemplatesSettingNames.Color1); } }
        public string Color2 { get { return SettingManager.GetSettingValue(MessageTemplatesSettingNames.Color2); } }
        public string Color3 { get { return SettingManager.GetSettingValue(MessageTemplatesSettingNames.Color3); } }
    }
}
using System.Collections.Generic;
using Abp.Configuration;
using Abp.Localization;

namespace Lyu.Abp.Core.Messages
{
    public class MessageTemplatesSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                new SettingDefinition(MessageTemplatesSettingNames.CaseInvariantReplacement, "false",new FixedLocalizableString("替换默认"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                new SettingDefinition(MessageTemplatesSettingNames.Color1, "#b9babe", new FixedLocalizableString("颜色1"),scopes: SettingScopes.Application | SettingScopes.Tenant),
                new SettingDefinition(MessageTemplatesSettingNames.Color2, "#ebecee", new FixedLocalizableString("颜色2"),scopes: SettingScopes.Application | SettingScopes.Tenant),
                new SettingDefinition(MessageTemplatesSettingNames.Color3, "#dde2e6", new FixedLocalizableString("颜色3"),scopes: SettingScopes.Application | SettingScopes.Tenant)
            };
        }
    }
}
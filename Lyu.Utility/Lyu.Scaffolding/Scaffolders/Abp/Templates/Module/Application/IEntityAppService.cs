using Lyu.Scaffolding.Models;
using Lyu.Scaffolding.Scaffolders.Abp;

namespace Lyu.Scaffolding.Scaffolders.Abp.Templates.Module.FunctionFolderName
{
    public class IEntityAppService : AbpTemplate
    {
        public IEntityAppService(TemplateParams templateParams) : base(templateParams)
        {
            _filename = @"Application\{FunctionFolderName}\I{Entity}AppService.cs";
        }
    }
}
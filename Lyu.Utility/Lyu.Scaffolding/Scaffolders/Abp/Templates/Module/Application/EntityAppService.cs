using Lyu.Scaffolding.Models;

namespace Lyu.Scaffolding.Scaffolders.Abp.Templates.Module.FunctionFolderName
{
    public class EntityAppService: AbpTemplate
    {
        public EntityAppService(TemplateParams templateParams) : base(templateParams)
        {
            _filename = @"Application\{FunctionFolderName}\{Entity}AppService.cs";
        }
    }
}
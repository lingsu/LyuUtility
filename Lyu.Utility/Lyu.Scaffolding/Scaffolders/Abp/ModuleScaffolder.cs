using System.Linq;
using Lyu.Scaffolding.Domain;
using Lyu.Scaffolding.Models;
using Lyu.Scaffolding.Utils;

namespace Lyu.Scaffolding.Scaffolders.Abp
{
    public class ModuleScaffolder
    {
        public ModuleScaffolder()
        {
            var type = typeof (Product);
            var templateParams = new TemplateParams();
            templateParams.EntityName = type.Name;
            templateParams.FunctionFolderName = VmUtils.ToPlural(templateParams.EntityName);
            templateParams.EntityNamespace = type.Namespace;
            templateParams.ModuleNamespace = getModuleNamespace(templateParams.EntityNamespace);
            templateParams.ModuleName = getModuleName(templateParams.ModuleNamespace);

        }


        private string getModuleName(string moduleNamespace)
        {
            return moduleNamespace.Split('.').Last();
        }

        private string getModuleNamespace(string entityNamespace)
        {
            var list = entityNamespace.Split('.').ToList();
            if (entityNamespace.Contains("YMC.Entities."))  //YMC.Entities.Content  
            {
                return "YMC.ECCentral." + list[2];
            }
            if (list.Contains("Domain"))  //命名空间包含Domain时， 去除Domain以后的
            {
                int index = list.IndexOf("Domain");
                if (index > 0)
                {
                    list.RemoveRange(index, list.Count - index);
                }
            }
            return string.Join(".", list);
        }
    }
}
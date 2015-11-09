using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Lyu.Scaffolding.Domain;
using Lyu.Scaffolding.Models;
using Lyu.Scaffolding.Scaffolders.Abp.Templates.Module.FunctionFolderName;
using Lyu.Scaffolding.Utils;

namespace Lyu.Scaffolding.Scaffolders.Abp
{
    public class ModuleScaffolder
    {
        public ModuleScaffolder()
        {
            var type = typeof(Product);
            var templateParams = new TemplateParams();
            templateParams.EntityName = type.Name;
            templateParams.EntityNamespace = type.Namespace;
            templateParams.ModuleNamespace = getModuleNamespace(templateParams.EntityNamespace);
            templateParams.ModuleName = getModuleName(templateParams.ModuleNamespace);

            MetaTableInfo dataModel = new MetaTableInfo();
            foreach (var propertyInfo in type.GetProperties())
            {
                var metaColumnInfo = new MetaColumnInfo();
                var aliase = VmUtils.ToGenericTypeString(propertyInfo.PropertyType);
                var descAttributes = propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                var description = descAttributes.Length == 1 ? ((DescriptionAttribute)descAttributes[0]).Description : aliase;

            }


            templateParams.DtoMetaTable = dataModel;

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
using System.Linq;
using System.Reflection;
using Lyu.Scaffolding.Models;

namespace Lyu.Scaffolding.Scaffolders.Abp
{
    public class ModuleScaffolder
    {
        public ModuleScaffolder()
        {
            //var type = typeof(Product);
            Assembly assembly = Assembly.Load(@"N:\Vs\Lyutemplate\Lyutemplate.Core\bin\Debug\Lyutemplate.Core.dll");
           
            foreach (var type in assembly.GetTypes().Where(m => m.GetInterface("IEntity",true) != null && !m.IsAbstract))
            {
                var templateParams = new TemplateParams();
                templateParams.EntityName = type.Name;
                templateParams.EntityNamespace = type.Namespace;
                templateParams.ModuleNamespace = getModuleNamespace(templateParams.EntityNamespace);
                templateParams.ModuleName = getModuleName(templateParams.ModuleNamespace);

                MetaTableInfo dataModel = new MetaTableInfo();
                foreach (var propertyInfo in type.GetProperties())
                {
                    var metaColumnInfo = new MetaColumnInfo(propertyInfo);
                    dataModel.Columns.Add(metaColumnInfo);
                }
                templateParams.DtoMetaTable = dataModel;
            }

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
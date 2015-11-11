using System.IO;
using System.Linq;
using System.Reflection;
using Lyu.Scaffolding.Models;
using Lyu.Scaffolding.Utils;

namespace Lyu.Scaffolding.Scaffolders.Abp
{
    public class AreaScaffolder
    {
        public AreaScaffolder()
        {
            //var type = typeof(Product);
            byte[] fileData = System.IO.File.ReadAllBytes(@"C:\Users\q25a2\Downloads\LyuTemplate\LyuTemplate.Core\bin\Debug\Lyutemplate.Core.dll");

            Assembly assembly = Assembly.Load(fileData);

            foreach (var type in assembly.GetTypes().Where(m => m.GetInterface("IEntity", true) != null && !m.IsAbstract))
            {
                var templateParams = new TemplateParams();
                templateParams.EntityName = type.Name;
                templateParams.entityName = ToCamelCase(templateParams.EntityName);
                templateParams.EntityNamespace = type.Namespace;
                templateParams.ModuleNamespace = getModuleNamespace(templateParams.EntityNamespace);
                templateParams.ModuleName = getModuleName(templateParams.ModuleNamespace);
                templateParams.FunctionFolderName = VmUtils.ToPlural(templateParams.ModuleName);
                templateParams.FunctionName = "FunctionName";
                templateParams.AllowBatchDelete = true;
                WriteLog(templateParams.EntityName);
                WriteLog(templateParams.entityName);
                WriteLog(templateParams.EntityNamespace);
                WriteLog(templateParams.ModuleNamespace);
                WriteLog(templateParams.ModuleName);
                MetaTableInfo dataModel = new MetaTableInfo();
                foreach (var propertyInfo in type.GetProperties())
                {
                    var metaColumnInfo = new MetaColumnInfo(propertyInfo);
                    dataModel.Columns.Add(metaColumnInfo);
                }
                templateParams.DtoMetaTable = dataModel;

                //var templates = new AbpTemplate[]{
                //        new IEntityAppService(templateParams),
                //        new EntityAppService(templateParams),
                //        new Repository(templateParams),
                //        new IRepository(templateParams)
                // };
                //string currentPath = Path.GetDirectoryName(Host.TemplateFile);
                //string projectPath = currentPath.Substring(0, currentPath.IndexOf(@"\Scaffolders"));

                //var functionFolderName = "functionFolderName";
                //string outputPath = Path.Combine(projectPath, @"_GeneratedCode\");
                //foreach (var template in templates)
                //{

                //    template.Output.Encoding = Encoding.UTF8;
                //    template.RenderToFile(Path.Combine(outputPath, template.FileName()));
                //}
            }

        }


        private void WriteLog(string str)
        {
            File.AppendAllText("D:\\Scaffolder.log.txt", str + "\r\n");
        }
        public string ToCamelCase(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            if (str.Length == 1)
            {
                return str.ToLower();
            }

            return char.ToLower(str[0]) + str.Substring(1);
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
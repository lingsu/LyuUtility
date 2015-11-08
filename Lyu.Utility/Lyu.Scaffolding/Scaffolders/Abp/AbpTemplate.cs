using Lyu.Scaffolding.Models;

namespace Lyu.Scaffolding.Scaffolders.Abp
{
    public abstract class AbpTemplate
    {
        protected readonly TemplateParams _templateParams;
        protected string _filename;

        public AbpTemplate(TemplateParams templateParams)
        {
            _templateParams = templateParams;
        }


        public string FileName()
        {
            var outputPath = _filename;
            outputPath = string.IsNullOrWhiteSpace(_templateParams.FunctionFolderName) ? outputPath.Replace(@"\{FunctionFolderName}", "") : outputPath.Replace("{FunctionFolderName}", _templateParams.FunctionFolderName);

            return outputPath.Replace("{Module}", _templateParams.ModuleName)
                .Replace("{Entity}", _templateParams.EntityName);
        }

        public string ProjectNamespace
        {
            get { return _templateParams.ProjectNamespace; }
        }

        public string EntityNamespace { get { return _templateParams.EntityNamespace; } }
        public string ModuleNamespace { get { return _templateParams.ModuleNamespace; } }
        public string ModuleName { get { return _templateParams.ModuleName; } }
        public string EntityName { get { return _templateParams.EntityName; } }
        public string entityName { get { return _templateParams.entityName; } }
        public string FunctionName { get { return _templateParams.FunctionName; } }
        public MetaTableInfo DtoMetaTable { get { return _templateParams.DtoMetaTable; } }
        public MetaTableInfo ItemMetaTable { get { return _templateParams.ItemMetaTable; } }
        public bool AllowBatchDelete { get { return _templateParams.AllowBatchDelete; } }
        public bool GenerateTwoCol { get { return _templateParams.GenerateTwoCol; } }
        public bool IsDisplayOrderable { get { return _templateParams.IsDisplayOrderable; } }
    }


  
}
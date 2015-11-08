namespace Lyu.Scaffolding.Models
{
    public class TemplateParams
    {
         public string FunctionFolderName { get; set; }
         public string ProjectNamespace { get; set; }
         public string EntityNamespace { get; set; }
         public string ModuleNamespace { get; set; }
         public string ModuleName { get; set; }
         public string EntityName { get; set; }
         public string entityName { get; set; }
         public string FunctionName { get; set; }
         public MetaTableInfo DtoMetaTable { get; set; }
         public MetaTableInfo ItemMetaTable { get; set; }
         public bool AllowBatchDelete { get; set; }
         public bool GenerateTwoCol { get; set; }
         public bool IsDisplayOrderable { get; set; }
    }
}
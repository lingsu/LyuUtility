using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using System.Linq;

namespace Lyu.Scaffolding.Utils
{
    public static class VmUtils
    {

        public static string ToGenericTypeString(Type t)
        {
            if (!t.IsGenericType)
                return Aliases.ContainsKey(t)
                    ? Aliases[t]
                    : t.Name;
            string genericTypeName = t.GetGenericTypeDefinition().Name;
            genericTypeName = genericTypeName.Substring(0,
                genericTypeName.IndexOf('`'));
            string genericArgs = string.Join(",",
                t.GetGenericArguments()
                    .Select(ToGenericTypeString).ToArray());
            return genericTypeName + "<" + genericArgs + ">";
        }

        public static readonly Dictionary<Type, string> Aliases =
            new Dictionary<Type, string>()
            {
                {typeof (byte), "byte"},
                {typeof (sbyte), "sbyte"},
                {typeof (short), "short"},
                {typeof (ushort), "ushort"},
                {typeof (int), "int"},
                {typeof (uint), "uint"},
                {typeof (long), "long"},
                {typeof (ulong), "ulong"},
                {typeof (float), "float"},
                {typeof (double), "double"},
                {typeof (decimal), "decimal"},
                {typeof (object), "object"},
                {typeof (bool), "bool"},
                {typeof (char), "char"},
                {typeof (string), "string"},
                {typeof (void), "void"}
            };


        /// <summary>
        /// 单词变成单数形式
        /// </summary>
        public static string ToSingular(string word)
        {
            Regex plural1 = new Regex("(?<keep>[^aeiou])ies$");
            Regex plural2 = new Regex("(?<keep>[aeiou]y)s$");
            Regex plural3 = new Regex("(?<keep>[sxzh])es$");
            Regex plural4 = new Regex("(?<keep>[^sxzhyu])s$");

            if (plural1.IsMatch(word))
                return plural1.Replace(word, "${keep}y");
            else if (plural2.IsMatch(word))
                return plural2.Replace(word, "${keep}");
            else if (plural3.IsMatch(word))
                return plural3.Replace(word, "${keep}");
            else if (plural4.IsMatch(word))
                return plural4.Replace(word, "${keep}");

            return word;
        }

        /// <summary>
        /// 单词变成复数形式
        /// </summary>
        public static string ToPlural(string word)
        {
            Regex plural1 = new Regex("(?<keep>[^aeiou])y$");
            Regex plural2 = new Regex("(?<keep>[aeiou]y)$");
            Regex plural3 = new Regex("(?<keep>[sxzh])$");
            Regex plural4 = new Regex("(?<keep>[^sxzhy])$");

            if (plural1.IsMatch(word))
                return plural1.Replace(word, "${keep}ies");
            else if (plural2.IsMatch(word))
                return plural2.Replace(word, "${keep}s");
            else if (plural3.IsMatch(word))
                return plural3.Replace(word, "${keep}es");
            else if (plural4.IsMatch(word))
                return plural4.Replace(word, "${keep}s");

            return word;
        }


        public static string getCName(string name, string docComment)
        {
            if (MustNameTable.Keys.Contains(name))
            {
                return MustNameTable[name];
            }
            string displayName = null;
            if (DefaultNameTable.Keys.Contains(name))
            {
                displayName = DefaultNameTable[name];
            }
            if (string.IsNullOrWhiteSpace(docComment))
                return displayName;
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(docComment);
            }
            catch
            {
                return displayName;
            }
            var el = doc.SelectSingleNode("//summary") as XmlElement;
            if (el != null)
            {
                displayName = Regex.Replace(el.InnerText, "[\\s]+", "");  //.Replace("\r", "").Replace("\n", "");
            }
            doc = null;
            return displayName;
        }

        public static Dictionary<string, string> _MustNameTable;
        public static Dictionary<string, string> MustNameTable
        {
            get
            {
                if (_MustNameTable == null)
                {
                    _MustNameTable = new Dictionary<string, string>();
                    _MustNameTable.Add("CreationTime", "创建时间");
                    _MustNameTable.Add("LastModificationTime", "最后编辑时间");

                }
                return _MustNameTable;
            }
        }

        public static Dictionary<string, string> _DefaultNameTable;
        public static Dictionary<string, string> DefaultNameTable
        {
            get
            {
                if (_DefaultNameTable == null)
                {
                    _DefaultNameTable = new Dictionary<string, string>();
                    _DefaultNameTable.Add("Remark", "备注");
                    _DefaultNameTable.Add("Description", "说明");
                    _DefaultNameTable.Add("Content", "内容");
                    _DefaultNameTable.Add("PicUrl", "图片地址");
                }
                return _DefaultNameTable;
            }
        }

        public static List<string> _DefaultHiddenFields;
        public static List<string> DefaultHiddenFields
        {
            get
            {
                if (_DefaultHiddenFields == null)
                {
                    _DefaultHiddenFields = new List<string>(
                        new string[] { "Id"
                            ,"CreatorUserId"
                            , "LastModifierUserId"
                            , "DeleterUserId"
                            , "DeletionTime"
                            , "IsDeleted"
                        });
                }
                return _DefaultHiddenFields;
            }
        }

        public static List<string> _DtoUnSelectFields;
        public static List<string> DtoUnSelectFields
        {
            get
            {
                if (_DtoUnSelectFields == null)
                {
                    _DtoUnSelectFields = new List<string>(
                        new string[] { "TenantId"
                            ,"GardenId"
                            ,"PropertyId"
                            ,"StoreId"
                            ,"CreationTime"
                            ,"LastModificationTime"
                            ,"DisplayOrder"
                        });
                }
                return _DtoUnSelectFields;
            }
        }

        public static List<string> _ItemUnSelectFields;
        public static List<string> ItemUnSelectFields
        {
            get
            {
                if (_ItemUnSelectFields == null)
                {
                    _ItemUnSelectFields = new List<string>(
                        new string[] { "TenantId"
                            ,"GardenId"
                            ,"PropertyId"
                            ,"StoreId"
                            //,"CreationTime"
                            ,"LastModificationTime"
                            ,"DisplayOrder"
                        });
                }
                return _ItemUnSelectFields;
            }
        }

    }
}
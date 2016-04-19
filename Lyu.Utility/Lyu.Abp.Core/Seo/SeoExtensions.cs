using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;
using Abp.Extensions;
using Pinyin4net;
using Pinyin4net.Format;
using System.Linq;

namespace Lyu.Core.Seo
{
    public static class SeoExtensions
    {
        private static readonly List<string> ReservedUrlRecordSlugs = new List<string>
        {
            "admin",
            "install",
            "recentlyviewedproducts",
            "newproducts",
            "compareproducts",
            "clearcomparelist",
            "setproductreviewhelpfulness",
            "login",
            "register",
            "logout",
            "cart",
            "wishlist",
            "emailwishlist",
            "checkout",
            "onepagecheckout",
            "contactus",
            "passwordrecovery",
            "subscribenewsletter",
            "blog",
            "boards",
            "inboxupdate",
            "sentupdate",
            "news",
            "sitemap",
            "search",
            "config",
            "eucookielawaccept",
            "page-not-found"
        };

        public static string ValidateSeName<T>(this T entity, string seName, string name, Func<string, T> nameCheck) where T : IEntity<int>
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            if (nameCheck == null)
                throw new ArgumentNullException("nameCheck");

            if (String.IsNullOrWhiteSpace(seName) && !String.IsNullOrWhiteSpace(name))
                seName = name;

            seName = GetSeName(seName);

            seName = seName.Truncate(200);

            if (String.IsNullOrWhiteSpace(seName))
            {
                return seName;
            }

            int i = 2;
            var tempSeName = seName;

            while (true)
            {
                var urlRecord = nameCheck(tempSeName);
                var reserved1 = urlRecord != null && urlRecord.Id != entity.Id;
                var reserved2 = ReservedUrlRecordSlugs.Contains(tempSeName, StringComparer.InvariantCultureIgnoreCase);

                if (!reserved1 && !reserved2)
                    break;

                tempSeName = string.Format("{0}-{1}", seName, i);
                i++;
            }
            seName = tempSeName;

            return seName;
        }

        public static string GetSeName(string name)
        {
            if (String.IsNullOrEmpty(name))
                return name;

            string okChars = "abcdefghijklmnopqrstuvwxyz1234567890 _-";
            name = name.Trim().ToLowerInvariant();

            var sb = new StringBuilder();

            HanyuPinyinOutputFormat format = new HanyuPinyinOutputFormat();
            format.ToneType = HanyuPinyinToneType.WITHOUT_TONE;

            foreach (char c in name.ToCharArray())
            {
                string c2 = c.ToString();
                int i = (int)c;
                if (i < 0x4e00 || i > 0x9fa5)
                {
                    if (okChars.Contains(c2))
                    {
                        sb.Append(c2);
                    }
                }
                else
                {
                    string[] pinyinStr = PinyinHelper.ToHanyuPinyinStringArray(c, format);
                    if (pinyinStr != null && pinyinStr.Length > 0)
                    {
                        sb.Append(pinyinStr[0]);
                    }
                }
            }

            string name2 = sb.ToString();
            name2 = name2.Replace(" ", "-");
            while (name2.Contains("--"))
                name2 = name2.Replace("--", "-");
            while (name2.Contains("__"))
                name2 = name2.Replace("__", "_");
            return name2;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Core.Helpers
{
    public static class InnerTextExtenstion
    {
        public static string GetAddress(this string str)
        {
            var arr = str.Split(',');
            var tmp = arr.Where(x => x.Contains('@'));
            return tmp.FirstOrDefault() ?? "";
        }

        public static string GetPhone(this string str)
        {
            var arr = str.Split(',');
            return string.Join(" , ", arr.Where(x => !x.Contains('@')));
        }

        public static string GetName(this string str)
        {
            var arr = str.Split(',');
            return arr.FirstOrDefault() ?? "";
        }

        public static string GetProfession(this string str)
        {
            var arr = str.Split(',');
            return string.Join(",", arr.Skip(1));
        }
    }
}

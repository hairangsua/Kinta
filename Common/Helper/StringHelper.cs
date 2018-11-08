using System;
using System.Collections.Generic;
using System.Linq;

namespace Kinta.Common.Helper
{
    public static partial class StringHelper
    {
        public static string FormatStr(this string self, params string[] stringArr)
        {
            return string.Format(self, stringArr);
        }

        public static bool IsEmpty(this string self)
        {
            return string.IsNullOrEmpty(self);
        }

        public static bool IsNotEmpty(this string self)
        {
            return !IsEmpty(self);
        }

        public static string RemoveSpecifyChar(this string source, char c)
        {
            if (source.IsEmpty())
            {
                throw new ArgumentNullException(nameof(source));
            }
            var newLst = new List<char>();
            foreach (var ch in source.ToList())
            {
                if (ch != c)
                {
                    newLst.Add(ch);
                }
            }
            return string.Join("", newLst);
        }
    }
}


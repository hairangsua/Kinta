using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace Kinta.Framework.Helper
{
    public static partial class CollectionHelper
    {
        public static bool IsNullOrEmpty(this ICollection self)
        {
            if (self == null)
            {
                return true;
            }

            if (self.Count == 0)
            {
                return true;
            }

            return false;
        }

        public static bool HasItem(this ICollection self)
        {
            return !self.IsNullOrEmpty();
        }

        public static T GetFirst<T>(this IEnumerable<T> source)
        {
            return source.FirstOrDefault();
        }

        public static T GetLast<T>(this IEnumerable<T> source)
        {
            return source.LastOrDefault();
        }
    }
}

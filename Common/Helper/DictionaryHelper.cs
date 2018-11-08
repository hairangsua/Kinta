using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Common.Helper
{
    public static partial class DictionaryHelper
    {
        public static bool IsEmpty<TKey, TValue>(this Dictionary<TKey, TValue> dic)
        {
            bool isEmpty;
            using (var dictionaryEnum = dic.GetEnumerator())
            {
                isEmpty = !dictionaryEnum.MoveNext();
            }

            return isEmpty;
        }

        public static bool IsNotEmpty<TKey, TValue>(this Dictionary<TKey, TValue> dic)
        {
            return !dic.IsEmpty();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Framework.Helper
{
    public static partial class BooleanHelper
    {
        public static bool IsTrue(bool value)
        {
            return value == true;
        }

        public static bool IsFalse(bool value)
        {
            return !IsTrue(value);
        }
    }
}

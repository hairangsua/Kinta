using System;

namespace Kinta.Framework.Helper
{
    public static partial class IdHelper
    {
        public static string NewGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Kinta.Common;

namespace Kinta.Common.Helper
{
    public static partial class IdHelper
    {
        public static string NewGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}

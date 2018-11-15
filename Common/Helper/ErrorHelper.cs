﻿using Kinta.Domain.Errors;

namespace Kinta.Common.Helper
{
    public static class ErrorHelper
    {
        public static bool IsNotOK(this Error error)
        {
            return error.Code != Error.OK.Code;
        }
    }
}
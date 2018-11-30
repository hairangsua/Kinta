using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Kinta.Framework.BaseExceptions
{
    public class AuthenticateException : Exception
    {
        public AuthenticateException() : base() { }

        public AuthenticateException(string message) : base(message) { }

        public AuthenticateException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}

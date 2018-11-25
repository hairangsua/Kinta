using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Framework.Exceptions
{
    public class Error
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public Error(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public Error(string message)
        {
            Code = 9999;
            Message = message;
        }

        public Error(Exception ex)
        {
            Code = 9999;
            Message = ex.Message;
        }

        public static Error OK { get { return new Error(200, "OK"); } }

        public static implicit operator string(Error e)
        {
            return e.Message;
        }

        public static implicit operator Error(string message)
        {
            return new Error(9999, message);
        }

        public static implicit operator Error(Exception ex)
        {
            return new Error(9999, ex.Message);
        }
    }

    public static class ErrorHelper
    {
        public static bool IsNotOk(this Error err)
        {
            return err.Code == 200;
        }
    }
}

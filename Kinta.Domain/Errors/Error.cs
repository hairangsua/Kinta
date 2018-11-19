using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Domain.Errors
{
    public partial class Error
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public Error(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public Error(Exception ex)
        {
            Code = 9999;
            Message = ex.Message;
        }

        public static Error OK { get { return new Error(0, "OK"); } }

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
}

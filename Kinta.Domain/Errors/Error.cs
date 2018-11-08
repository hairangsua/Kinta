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

        public static Error OK { get { return new Error(0, "OK"); } }
    }
}

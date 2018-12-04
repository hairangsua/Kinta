using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Framework.Response
{
    public class ServiceError
    {
        public string Code { get; set; }
        public string Arguments { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}

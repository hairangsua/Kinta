using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Common.DTO
{
    public class NumberCodeName
    {
        public int Code { get; set; }
        public string Name { get; set; }

        public NumberCodeName(int code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}

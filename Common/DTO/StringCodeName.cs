using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Common.DTO
{
    public class StringCodeName
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public StringCodeName(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}

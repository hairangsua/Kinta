using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Common.Helper
{
    public class JSONHelper
    {
        public static TEntity Parse<TEntity>(string jsonText)
        {
            return JsonConvert.DeserializeObject<TEntity>(jsonText);
        }

        public static string Stringify<TEntity>(TEntity obj)
        {
            //TO DO: JSON Setting
            return JsonConvert.SerializeObject(obj);
        }
    }
}

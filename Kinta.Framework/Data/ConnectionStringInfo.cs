using Kinta.Framework.Helper;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kinta.Framework.Data
{
    /// <summary>
    /// Đọc dữ liệu file json
    /// </summary>
    public class ConnectionStringInfo
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool Enabled { get; set; }

        public static ConnectionStringInfo GetConnectionByName(string dbName)
        {
            var path = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Configuration\connections.json";
            string text = File.ReadAllText(path);
            var connectionGroup = JSONHelper.Parse<ConnectionGroup>(text);
            var connectionInfos = connectionGroup.Connections;
            return connectionInfos.FirstOrDefault(x => x.Enabled && x.Name == dbName);
        }
    }

    public class ConnectionGroup
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public List<ConnectionStringInfo> Connections { get; set; }
    }


}

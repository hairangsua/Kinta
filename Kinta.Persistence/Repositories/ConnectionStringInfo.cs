using Kinta.Common.Helper;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kinta.Persistence.Repositories
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
            //TO DO: use relative path
            string text = File.ReadAllText(@"C:\Work\Kinta\ShareConfig\connections.json");
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

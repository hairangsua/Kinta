using Json;
using Kinta.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    public class TestReadFileInProject
    {
        public static void InitTest()
        {
            //var a = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());
            //var path = Path.Combine("", "ShareConfig\\connection.json");
            //string text = File.ReadAllText(path);

            string text = File.ReadAllText(@"C:\Work\Kinta\ShareConfig\connections.json");
            var connectionGroup = JsonParser.Deserialize<ConnectionGroup>(text);

            var connectionInfos = connectionGroup.Connections;
            var str = connectionInfos.FirstOrDefault(x => x.Enabled && x.Name == "db_kinta");
        }
    }
}

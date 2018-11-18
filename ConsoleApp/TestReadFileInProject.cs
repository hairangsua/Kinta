using Kinta.Persistence.Repositories;
using Newtonsoft.Json;
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

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"JukeboxV2.0\JukeboxV2.0\Datos\ich will.mp3");
            
            string text = File.ReadAllText(@"C:\Work\Kinta\ShareConfig\connections.json");
            var connectionGroup = JsonConvert.DeserializeObject<ConnectionGroup>(text);

            var connectionInfos = connectionGroup.Connections;
            var str = connectionInfos.FirstOrDefault(x => x.Enabled && x.Name == "db_kinta");
        }
    }
}

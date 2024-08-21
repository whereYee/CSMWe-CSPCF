using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Additional
{
    static class File
    {
        public static string Reader(string path)
        {
            string data;
            StreamReader reader = new StreamReader(path);
            data = reader.ReadLine();
            reader.Close();
            return data;
        }

        public static void Writer(string path, string data)
        {
            using(StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(data);
            }
        }
    }
    
}

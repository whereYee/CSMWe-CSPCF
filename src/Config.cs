using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Additional
{
    class ConfigManager
    {
        public static string name = Config.GetString("server_name", "");
        public static string info = Config.GetString("serverinfo_pastebin_id", "");
        public static int port = Config.GetInt("port", 0);
        public static int maxplayers = Config.GetInt("maxplayers", 0);
        public static int scp173_health = Config.GetInt("scp173_health", 0);
        public static int scp049_health = Config.GetInt("scp049_health", 0);
        public static int scp106_health = Config.GetInt("scp106_health", 0);
        public static int scp096_health = Config.GetInt("scp096_health", 0);
        public static int scp939_health = Config.GetInt("scp939_health", 0);
        public static int scp0492_health = Config.GetInt("scp0492_health", 0);
        public static int scp999_health = Config.GetInt("scp999_health", 0);
    }
}

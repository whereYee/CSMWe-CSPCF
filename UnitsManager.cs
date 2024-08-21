using Akequ.Base;
using UnityEngine;

namespace Plugin.Additional
{
    public static class UnitsManager
    {
        

        public static void GiveItems(string[] items, Player player)
        {
            foreach(string item in items)
            {
                player.GiveItem(item);
            }
        }

        public static void GiveAmmo(Player player)
        {
            for (int i = 0; i < 120; i++)
            {
                player.GiveItem("Ammo.A45");
                player.GiveItem("Ammo.A9x19");
                player.GiveItem("Ammo.A46x30");
                player.GiveItem("Ammo.A545x39");
                player.GiveItem("Ammo.A556x45");
                player.GiveItem("Ammo.A556x45");
                player.GiveItem("Ammo.A762x39");
            }
        }

        public static void hitMe(int damge, Player player)
        {
            var hp = player.health + damge;
            if (hp <= player.maxHealth)
            {
                DamageHandler hpRun = new DamageHandler();
                hpRun.damage = (short)damge;
                player.ChangeHealth(hpRun);
            }
        }

        public static void SetPeople(int number, string units)
        {
            var players = AllPlayer.GetSpectatorListPlayer();
            if(players.Count >= number)
            {
                for (int i = 0; i < number; i++)
                {
                    var player = players[UnityEngine.Random.Range(0, players.Count - 1)];
                    player.SetClass(units);
                    players.Remove(player);
                }
            }
            
        }

        public static void GivePlugins(Item[] items, Player player)
        {
            foreach (Item item in items)
            {
                player.AddToInventory(item);
            }
        }

        public struct Color16
        {
            public static string Orange = "FF8E00";
            public static string Blue = "0099CC";
            public static string Yellow = "FFCC00";
            public static string Red = "FF0000";
            public static string Brown = "666666";
            public static string write = "FFFFF";
            public static string Fuchsia = "FF33FF";
            public static string Green = "00FF00";
        }

        public struct Head
        {
            public static string ClassD = "ClassDHand";
            public static string MTF = "MTFHand";
            public static string Scientist = "ScientistHand";
            public static string Guard = "GuardHand";
            public static string Chaos = "ChaosHand";
        }

        public struct SpawnPoint
        {
            public static string ClassD = "classDSpawn";
            public static string MTF = "mtfSpawn";
            public static string Scientist = "scientistSpawn";
            public static string Guard = "guardSpawn";
            public static string Chaos = "chaosSpawn";
            public static string SCP049 = "scp049Spawn";
            public static string SCP173 = "scp173Spawn";
            public static string SCP096 = "scp096Spawn";
        }

        public struct TeamID
        {
            public static string ClassD = "ClassD";
            public static string MTF = "MTF";
            public static string SCP = "SCP";
        }

        public struct Ply
        {
            public static string ClassD = "ply_classD";
            public static string MTF = "ply_mtf";
            public static string Scientist = "ply_scientist";
            public static string Guard = "ply_guard";
            public static string Chaos = "ply_chaos";
            public static string SCP0492 = "ply_zombie";
        }

        public struct HpColor
        {
            public static Color Red = new Color(255, 0, 0);
            public static Color Black = new Color(0, 0, 0);
            public static Color Write = new Color(255, 255, 255);
            public static Color Blue = new Color(0, 0, 255);
            public static Color Green = new Color(0, 255, 0);
            public static Color Yellow = new Color(255, 255, 0);
            public static Color Gray = new Color(192, 192, 192);
            public static Color Orange = new Color(255, 128, 0);
        }

    }
}

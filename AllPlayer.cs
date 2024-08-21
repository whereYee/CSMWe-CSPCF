using Akequ.Base;
using System.Collections.Generic;
using UnityEngine;


namespace Plugin.Additional
{
    public class AllPlayer : Room
    {
        /// <summary>
        /// 获取全部玩家
        /// </summary>
        /// <returns></returns>
        public static Player[] GetAllPlayer()
        {
            return GameObject.FindObjectsOfType<Player>();
        }

        /// <summary>
        /// 获取全部SCP玩家
        /// </summary>
        /// <returns></returns>
        public static List<Player> GetSCPListPlayer()
        {
            List<Player> scps = new List<Player>();
            foreach (Player player in GetAllPlayer())
            {
                PlayerClassProxy proxy = player.playerClass as PlayerClassProxy;
                if (proxy != null)
                {
                    if (proxy.GetTeamID() == "SCP")
                    {
                        scps.Add(player);
                    }
                }
            }
            return scps;
        }

        /// <summary>
        /// 获取全部MTF玩家
        /// </summary>
        /// <returns></returns>
        public static List<Player> GetMTFListPlayer()
        {
            List<Player> scps = new List<Player>();
            foreach (Player player in GetAllPlayer())
            {
                PlayerClassProxy proxy = player.playerClass as PlayerClassProxy;
                if (proxy != null)
                {
                    if (proxy.GetTeamID() == "MTF")
                    {
                        scps.Add(player);
                    }
                }
            }
            return scps;
        }

        /// <summary>
        /// 获取全部ClassD玩家
        /// </summary>
        /// <returns></returns>
        public static List<Player> GetClassDListPlayer()
        {
            List<Player> scps = new List<Player>();
            foreach (Player player in GetAllPlayer())
            {
                PlayerClassProxy proxy = player.playerClass as PlayerClassProxy;
                if (proxy != null)
                {
                    if (proxy.GetTeamID() == "ClassD")
                    {
                        scps.Add(player);
                    }
                }
            }
            return scps;
        }

        /// <summary>
        /// 获取全部Spectator玩家
        /// </summary>
        /// <returns></returns>
        public static List<Player> GetSpectatorListPlayer()
        {
            var players = new List<Player>();
            foreach (Player player in GameObject.FindObjectsOfType<Player>())
            {
                if (player.playerClass.GetType().GetMethod("GetTeamID").Invoke(player.playerClass, null) as string == "Spectator") players.Add(player);
            }

            return players;
        }

        /// <summary>
        /// 获取一个随机玩家
        /// </summary>
        /// <returns></returns>
        public static Player GetRandomPlayer()
        {
            return GetAllPlayer()[UnityEngine.Random.Range(0, GetAllPlayer().Length)];
        }

        /// <summary>
        /// 获取玩家ID
        /// </summary>
        /// <param name="id">玩家ID</param>
        /// <returns></returns>
        public static Player GetIDPlayer(short id)
        {
            return PlayerUtilities.GetPlayer(id);
        }

        /// <summary>
        /// 获取玩家的类
        /// </summary>
        /// <param name="player">玩家</param>
        /// <returns></returns>
        public static PlayerClassProxy GetPlayerClass(Player player)
        {
            return player.playerClass as PlayerClassProxy;
        }
    }

}

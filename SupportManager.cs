using Akequ.Classes;
using Mirror;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Plugin.Additional
{
    public class SpawnManager : Akequ.Base.Room
    {
        private int Spectators;
        private int LifeMTFs;
        private int LifeClassDs;

        public override void Init()
        {
            if (netEvent.isServer)
            {
                List<string> StartRound_D = new List<string>();
                List<string> StartRound_S = new List<string>();
                List<string> StartRound_M = new List<string>();
                List<string> StartRound_MS = new List<string>();

                List<string> StartMiddle = new List<string>();
                List<string> StartMiddle2 = new List<string>();
                List<string> StartMiddle3 = new List<string>();

                List<string> SpswnM = new List<string>();
                List<string> SpswnC = new List<string>();
                List<Player> SpectatorList = new List<Player>();




                HookManager.Add("onRoundStart", (obj) =>
                {

                    var players = GameObject.FindObjectsOfType<Player>();
                    var ClassDs = new List<Player>();
                    var Guards = new List<Player>();
                    var Scientists = new List<Player>();
                    foreach (Player player in players)
                    {
                        string team = player.playerClass.GetType().GetMethod("GetName").Invoke(player.playerClass, null) as string;
                        if (team == "Class-D Personnel")
                        {
                            ClassDs.Add(player);
                        }
                        else if(team == "Guard")
                        {
                            Guards.Add(player);
                        }
                        else if (team == "Scientist")
                        {
                            Scientists.Add(player);
                        }
                    }

                    if (Guards.Count > 0)
                    {
                        foreach (string name in StartRound_M)
                        {

                            Player pl = Guards[UnityEngine.Random.Range(0, Guards.Count - 1)];
                            pl.SetClass(name);
                            Guards.Remove(pl);
                        }

                    }

                    if (ClassDs.Count > 0)
                    {
                        foreach (string name in StartRound_D)
                        {

                            Player pl = ClassDs[UnityEngine.Random.Range(0, ClassDs.Count - 1)];
                            pl.SetClass(name);
                            ClassDs.Remove(pl);
                        }
                    }

                    if (Scientists.Count > 0)
                    {
                        foreach (string name in StartRound_MS)
                        {

                            Player pl = Scientists[UnityEngine.Random.Range(0, Scientists.Count - 1)];
                            pl.SetClass(name);
                            Scientists.Remove(pl);
                        }
                    }


                    Invoke(() =>
                    {
                        var Peoples = AllPlayer.GetSpectatorListPlayer();

                        if (Peoples.Count > 0)
                        {
                            foreach (string name in StartMiddle)
                            {
                                Player pl = Peoples[UnityEngine.Random.Range(0, Peoples.Count - 1)];
                                pl.SetClass(name);
                                Peoples.Remove(pl);
                            }
                        }

                    }, 120);

                    Invoke(() =>
                    {
                        var Peoples = AllPlayer.GetSpectatorListPlayer();

                        if (Peoples.Count > 0)
                        {
                            foreach (string name in StartMiddle2)
                            {
                                Player pl = Peoples[UnityEngine.Random.Range(0, Peoples.Count - 1)];
                                pl.SetClass(name);
                                Peoples.Remove(pl);
                            }
                        }
                    }, 240);

                    Invoke(() =>
                    {
                        var Peoples = AllPlayer.GetSpectatorListPlayer();

                        if (Peoples.Count > 0)
                        {
                            foreach (string name in StartMiddle3)
                            {
                                Player pl = Peoples[UnityEngine.Random.Range(0, Peoples.Count - 1)];
                                pl.SetClass(name);
                                Peoples.Remove(pl);
                            }
                        }
                    }, 360);

                    Invoke(() =>
                    {
                        var Peoples = AllPlayer.GetSpectatorListPlayer();

                        if (Peoples.Count > 0)
                        {
                            Player pl = Peoples[UnityEngine.Random.Range(0, Peoples.Count - 1)];
                            Peoples.Remove(pl);

                        }
                    }, 300);

                });

                HookManager.Add("onSupportRequest", (obj) =>
                {
                    foreach (Player player in GameObject.FindObjectsOfType<Player>())
                    {
                        if (player.playerClass.GetType().GetMethod("GetTeamID").Invoke(player.playerClass, null) as string == "MTF") LifeMTFs++;
                        if (player.playerClass.GetType().GetMethod("GetTeamID").Invoke(player.playerClass, null) as string == "ClassD") LifeClassDs++;
                        if (player.playerClass.GetType().GetMethod("GetTeamID").Invoke(player.playerClass, null) as string == "Spectator") SpectatorList.Add(player);
                    }
                });

                HookManager.Add("onSupportSpawned", (obj) =>
                {
                    int thisMTFs = 0;
                    int thisClassDs = 0;

                    foreach (Player player in GameObject.FindObjectsOfType<Player>())
                    {
                        if (player.playerClass.GetType().GetMethod("GetTeamID").Invoke(player.playerClass, null) as string == "MTF") thisMTFs++;
                        if (player.playerClass.GetType().GetMethod("GetTeamID").Invoke(player.playerClass, null) as string == "ClassD") thisClassDs++;
                    }

                    
                    if (thisClassDs > LifeClassDs)
                    {
                        foreach (string units in SpswnC)
                        {
                            Player player = SpectatorList[UnityEngine.Random.Range(0, SpectatorList.Count - 1)];
                            player.SetClass(units);
                            SpectatorList.Remove(player);
                        }

                        LifeClassDs = 0;
                        LifeMTFs = 0;
                        SpectatorList = new List<Player>();
                    }
                    

                    if (thisMTFs > LifeMTFs)
                    {
                        foreach (string units in SpswnM)
                        {
                            Player player = SpectatorList[UnityEngine.Random.Range(0, SpectatorList.Count - 1)];
                            player.SetClass(units);
                            SpectatorList.Remove(player);
                        }

                        LifeClassDs = 0;
                        LifeMTFs = 0;
                        SpectatorList = new List<Player>();
                    }
                });
            }

            


        }

    }
}

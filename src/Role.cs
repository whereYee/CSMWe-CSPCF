using Plugin.Additional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Plugin.Additional
{
    public  class Role : Akequ.Base.PlayerClass
    {

        public override void Init()
        {

            player.InitHealth((uint)GetHp(), new Color(1f, 0f, 0f, 1f));
            if (player.isLocalPlayer)
            {
                player.PlayBellSound(1);
                UIManager.SetMobileButtons(new List<string>() { "Move", "Rotate", "Pause", "PlayerList", "Interact", "Jump", "Run",
                    "Inventory", "Voice" });
                TransitionManager.ShowClass(this.GetColor(), this.GetName(), this.GetInfo());
                player.SetSpeed(3.25f, 8.5f);
                player.SetJumpPower(2.5f);
                player.SetFootsteps(ResourcesManager.GetClips("Step1", "Step2", "Step3", "Step4", "Step5", "Step6",
                    "Step7", "Step8"));
                PlayerUtilities.SetVoiceChat("3D", "", false);
            }
            else
            {
                playerModel = GameObject.Instantiate(ResourcesManager.GetObject(GetModel())) as GameObject;
                playerModel.transform.parent = player.transform;
                playerModel.transform.localPosition = new Vector3(0f, -1.075f, 0f);
                playerModel.transform.localRotation = Quaternion.identity;
                playerModel.transform.localScale = new Vector3(1.45f, 1.45f, 1.45f);
                PlayerUtilities.SpawnHitboxes(player, playerModel);
            }

            if (player.isServer)
            {
                if (player.isClient)
                {
                    Transform[] points = player.GetSpawnPoints("Zone1", GetSpawnPoint());
                    Vector3 point = points[Random.Range(0, points.Length)].position;
                    player.Teleport(new Vector3(point.x, point.y + 1.25f, point.z));
                }
                else
                {
                    GameObject[] points = GameObject.FindGameObjectsWithTag(GetSpawnPoint());
                    Vector3 point = points[Random.Range(0, points.Length)].transform.position;
                    player.Teleport(new Vector3(point.x, point.y + 1.25f, point.z));
                    UnitsManager.GiveAmmo(player);
                    UnitsManager.GiveItems(new string[] { }, player);
                }
                float[] speed = GetSpeed();
                player.SetSpeed(speed[0], speed[1]);
            }
        }

        public override bool IgnoreSCP()
        {
            return true;

        }

        public override void OnStop()
        {
            if (playerModel != null)
            {
                PlayerUtilities.SpawnRagdoll(player, playerModel);
                GameObject.Destroy(playerModel);
            }
            else
            {
                PlayerUtilities.SpawnRagdoll(player, $"{GetModel()}_ragdoll").transform.localScale =
                    new Vector3(1.45f, 1.45f, 1.45f);
            }
        }

        public virtual float[] GetSpeed()
        {
            return new float[] { };
        }

        public virtual int GetHp()
        {
            return 0;
        }

        public override string GetHand()
        {
            return "";
        }

        public override string GetName()
        {
            return "";
        }

        public virtual string GetColor()
        {
            return "";
        }

        public override string GetTeamID()
        {
            return "";
        }

        public override string GetClassColor()
        {
            return "";
        }

        public virtual string GetInfo()
        {
            return "";
        }

        public virtual string GetModel()
        {
            return "";
        }

        public virtual string GetSpawnPoint()
        {
            return "";        }
    }
}

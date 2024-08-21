using Akequ.Base;
using Akequ.Items.Ammo;
using Akequ.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Additional
{
    class ItemManager
    {
        public struct 物品
        {
            public static string 硬币 = "Coin";
            public static string 捆绑器 = "Cuffer";
            public static string 茶 = "Cup";
            public static string 小医疗包 = "FirstAid";
            public static string 大医疗包 = "FirstAid2";
            public static string 闪光弹 = "FlashGrenade";
            public static string 手雷弹 = "FragGrenade";
            public static string 对讲机 = "Radio";
            public static string SCP420J = "SCP420J";
            public static string 清洁工卡 = "AnalystCard";
            public static string 助理卡 = "AssistantCard";
            public static string 设施区域管理卡 = "FacilityDirectorCard";
            public static string 设施主管卡 = "FacilityManagerCard";
            public static string 混沌卡 = "BreakingCard";
            public static string 收容专家卡 = "ContainmentSpecialistCard";
            public static string 基金会代理人卡 = "FoundationAgent";
            public static string 设施警卫卡 = "GuardCard";
            public static string 工程师卡 = "EngineerCard";
            public static string MTF指挥官 = "MTFCommanderCard";
            public static string MTF成员卡 = "MTFOperativeCard";
            public static string O5议会卡 = "O5Card";
            public static string 新成员卡 = "RecruitCard";
            public static string 科学家卡 = "ScientistCard";
            public static string 高级工程师卡 = "SeniorEngineerCard";
            public static string 高级科学家卡 = "SeniorScientistCard";
            public static string 区域经理卡 = "ZoneManagerCard";
        }

        public struct AmmoString
        {
            public static string A9 = "Ammo.A9x19";
            public static string A45 = "Ammo.A45";
            public static string A46x30 = "Ammo.A46x30";
            public static string A545x39 = "Ammo.A545x39";
            public static string A556x45 = "Ammo.A556x45";
            public static string A762x39 = "Ammo.A762x39";
        }

        public struct AmmoObj
        {
            public static Akequ.Base.Ammo A9 = new Akequ.Items.Ammo.A9x19();
            public static Akequ.Base.Ammo A45 = new Akequ.Items.Ammo.A45();
            public static Akequ.Base.Ammo A46x30 = new Akequ.Items.Ammo.A46x30();
            public static Akequ.Base.Ammo A545x39 = new Akequ.Items.Ammo.A545x39();
            public static Akequ.Base.Ammo A556x45 = new Akequ.Items.Ammo.A556x45();
            public static Akequ.Base.Ammo A762x39 = new Akequ.Items.Ammo.A762x39();
        }

        public struct WeaponString
        {
            public static string AK15 = "AK15";
            public static string CZ75B = "CZ75B";
            public static string HK416C = "HK416C";
            public static string KRISS = "KRISS";
            public static string MicroHID = "MicroHID";
            public static string MP7 = "MP7";
            public static string SR2M = "SR2M";
            public static string UMP45 = "UMP45";
            public static string USP = "USP";
        }

        public struct WeaponObj
        {
            public static Akequ.Base.Weapon AK15 = new Akequ.Items.AK15();
            public static Akequ.Base.Weapon CZ75B = new Akequ.Items.CZ75B();
            public static Akequ.Base.Weapon HK416C = new Akequ.Items.HK416C();
            public static Akequ.Base.Weapon KRISS = new Akequ.Items.KRISS();
            public static Akequ.Base.Weapon MP7 = new Akequ.Items.MP7();
            public static Akequ.Base.Weapon SR2M = new Akequ.Items.SR2M();
            public static Akequ.Base.Weapon UMP45 = new Akequ.Items.UMP45();
            public static Akequ.Base.Weapon USP = new Akequ.Items.USP();
        }

        




    }
}

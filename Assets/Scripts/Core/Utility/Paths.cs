using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core
{
    public static class Paths
    {
        public static string enemyDataPath = "ScriptableObjects/EnemyData/";
        public static string enemyPackPath = "ScriptableObjects/EnemyPacks/";
        public static string partyMemberPath = "ScriptableObjects/PartyMembers/";
        public static string weaponPath = "ScriptableObjects/Equipment/Weapons/";
        public static string armorPath = "ScriptableObjects/Equipment/Armors/";
        public static string accessoryPath = "ScriptableObjects/Equipment/Accessories/";

        //enemy data
        public static string Bug = enemyDataPath + "Bug";
        //enemy packs
        public static string TwoBug = enemyPackPath + "TwoBug";

        //party member
        public static string Alwyn = partyMemberPath + "AlwynEreghast";
        public static string Harald = partyMemberPath + "HaraldVarcona";
        public static string Levy = partyMemberPath + "LevyBlackstrand";
        public static string Burdukov = partyMemberPath + "Burdukow";

        //equipment - weapons
        public static string Dagger = weaponPath + "Dagger";
        public static string NoWeapon = weaponPath + "None";


        //equipment - armor
        public static string Shield = armorPath + "Shield";
        public static string NoArmor = armorPath + "None";

        //equipment - accesor
        public static string LuckyCharm = accessoryPath + "LuckyCharm";
        public static string NoAccessory = accessoryPath + "None";

        //other
        public static string BattleTransition = "BattleTransition";
    }
}

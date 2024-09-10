using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [Serializable]
    public class EnemyStats : BattleStats
    {
        [SerializeField] private int hp;
        [SerializeField] private int maxhp;
        [SerializeField] private int mp;
        [SerializeField] private int maxmp;
        [SerializeField] private int str;
        [SerializeField] private int arm;
        [SerializeField] private int spd;

        public override int HP => hp;
        public override int MaxHP => maxhp;
        public override int MP => mp;
        public override int MaxMP => maxmp;
        public override int STR => str;
        public override int ARM => arm;
        public override int SPD => spd;

        public override void HealHP(int amount)
        {
           
        }

        public override void ReduceHP(int amount)
        {
            if (amount <= 0)
                return;

            hp = Mathf.Clamp(hp - amount, 0, maxhp);
        }
    }
}
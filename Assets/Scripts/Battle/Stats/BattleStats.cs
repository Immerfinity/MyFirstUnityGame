using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public abstract class BattleStats
    {
        public static readonly int MAXIMUM_POSSIBLE_HP = 999;
        public static readonly int MAXIMUM_POSSIBLE_MP = 99;
        public static readonly int MAXIMUM_POSSIBLE_STR = 99;
        public static readonly int MAXIMUM_POSSIBLE_ARM = 99;
        public static readonly int MAXIMUM_POSSIBLE_SPD = 99;

        public abstract int HP { get; }
        public abstract int MaxHP { get; }
        public abstract int MP { get; }
        public abstract int MaxMP { get; }
        public abstract int STR { get; }
        public abstract int ARM { get; }
        public abstract int SPD { get; }

        public int Initiative => SPD + Random.Range(-1, 2);

        public abstract void ReduceHP(int amount);

        public abstract void HealHP(int amount);

        #region[Код статистики до исправления]
        /* [SerializeField] private int hp;
         [SerializeField] private int maxhp;
         [SerializeField] private int mp;
         [SerializeField] private int maxmp;
         [SerializeField] private int str;
         [SerializeField] private int arm;
         [SerializeField] private int spd;


         public BattleStats(int hp, int maxhp, int mp, int maxmp, int str, int arm, int spd)
         {
             this.hp = hp;
             this.maxhp = maxhp;
             this.mp = mp;
             this.maxmp = maxmp;
             this.str = str;
             this.arm = arm;
             this.spd = spd;
         }

         public int Initiative => SPD + Random.Range(-1, 2);

         public int HP
         {
             get => hp;
             set
             {
                 hp = Mathf.Clamp(value, 0, maxhp);
             }
         }

         public int MaxHP
         {
             get => maxhp;
             set
             {
                 maxhp = Mathf.Clamp(value, 1, MAXIMUM_POSSIBLE_HP);
             }
         }

         public int MP
         {
             get => mp;
             set
             {
                 mp = Mathf.Clamp(value, 0, maxmp);
             }
         }

         public int MaxMP
         {
             get => maxmp;
             set
             {
                 maxmp = Mathf.Clamp(value, 1, MAXIMUM_POSSIBLE_MP);
             }
         }

         public int STR
         {
             get => str;
             set
             {
                 str = Mathf.Clamp(value, 0, MAXIMUM_POSSIBLE_STR);
             }
         }

         public int ARM
         {
             get => arm;
             set
             {
                 arm = Mathf.Clamp(value, 0, MAXIMUM_POSSIBLE_ARM);
             }
         }

         public int SPD
         {
             get => spd;
             set
             {
                 spd = Mathf.Clamp(value, 0, MAXIMUM_POSSIBLE_SPD);
             }
         }*/
        #endregion
    }
}
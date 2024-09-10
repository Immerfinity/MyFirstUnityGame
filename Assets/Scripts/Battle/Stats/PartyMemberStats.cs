using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Battle
{
    public abstract class PartyMemberStats : BattleStats
    {
        public static PartyMemberStats CreateStats(PartyMember member)
        {
            return member.Job switch
            {
                Job.Needly => new NeedlyStats(member),
                Job.Cleric => new ClericStats(member),
                Job.Mage => new MageStats(member),
                Job.Burdukow => new BurdukovStats(member),
                _ => new NeedlyStats(member),
            };
        }

        protected int hp;

        public abstract int BaseMaxHP { get; }
        public abstract int BaseMaxMP { get; }
        public abstract int BaseSTR { get; }
        public abstract int BaseARM { get; }
        public abstract int BaseSPD { get; }

        public override void ReduceHP(int amount)
        {
            if (amount <= 0)
                return;

            hp = Mathf.Clamp(hp - amount, 0, MaxHP);
        }

        public override void HealHP(int amount)
        {
            hp += amount;
        }
    }
}
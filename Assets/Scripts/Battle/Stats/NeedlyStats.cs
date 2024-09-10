using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class NeedlyStats : PartyMemberStats
    {
        protected PartyMember member;
        protected int mp;

        //Party Member Stats
        public override int BaseMaxHP => 50;
        public override int BaseMaxMP => 1;
        public override int BaseSTR => 3;
        public override int BaseARM => 3;
        public override int BaseSPD => 2;

        //Bttle Stats
        public override int HP => hp;
        public override int MaxHP => BaseMaxHP;
        public override int MP => mp;
        public override int MaxMP => BaseMaxMP;
        public override int STR => member.EquippedWeapon is null ? BaseSTR : BaseSTR + member.EquippedWeapon.StrBonus;
        public override int ARM => member.EquippedArmor is null ? BaseARM : BaseARM + member.EquippedArmor.ArmBonus;
        public override int SPD => BaseSPD;


        public NeedlyStats(PartyMember member)
        {
            this.member = member;
            this.hp = BaseMaxHP;
            this.mp = BaseMaxMP;
        }
    }
}
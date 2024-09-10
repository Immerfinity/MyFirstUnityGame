using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class ClericStats : PartyMemberStats
    {
        protected PartyMember member;
        protected int mp;

        //Party Member Stats
        public override int BaseMaxHP => 100;
        public override int BaseMaxMP => 50;
        public override int BaseSTR => 2;
        public override int BaseARM => 1;
        public override int BaseSPD => 2;

        //Bttle Stats
        public override int HP => hp;
        public override int MaxHP => BaseMaxHP;
        public override int MP => mp;
        public override int MaxMP => BaseMaxMP;
        public override int STR => member.EquippedWeapon is null ? BaseSTR : BaseSTR + member.EquippedWeapon.StrBonus;
        public override int ARM => member.EquippedArmor is null ? BaseARM : BaseARM + member.EquippedArmor.ArmBonus;
        public override int SPD => BaseSPD;


        public ClericStats(PartyMember member)
        {
            this.member = member;
            this.hp = BaseMaxHP;
            this.mp = BaseMaxMP;
        }
    }
}

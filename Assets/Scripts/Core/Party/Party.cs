using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    public static class Party
    {
        public static List<PartyMember> activeMembers = new List<PartyMember>();
        private static List<PartyMember> reserveMembers = new List<PartyMember>();

        private static Inventory inventory = new Inventory();

        public static IReadOnlyList<PartyMember> ActiveMembers => activeMembers;
        public static IReadOnlyList<PartyMember> ReserveMembers => reserveMembers;
        public static Inventory Inventory => inventory;


        static Party()
        {
            GenerateStartingParty();
        }

        public static void AddActiveMember(PartyMember memberToAdd)
        {
            /*if (activeMembers.Contains(memberToAdd))
                return;*/

            activeMembers.Add(memberToAdd);
            reserveMembers.Remove(memberToAdd);
        }

        public static void RemoveactiveMember(PartyMember memberToRemove)
        {
            if (!activeMembers.Contains(memberToRemove))
                return;

            activeMembers.Remove(memberToRemove);
            reserveMembers.Add(memberToRemove);
        }

        public static void GenerateStartingParty()
        {
            inventory.Initialize();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Battle;

namespace Core
{
    public class PartyMemberInfo : MonoBehaviour
    {
        private PartyMember partyMember;
        private PartyMemberStats stats;

        [SerializeField] private Image memberPortrait;
        [SerializeField] private TextMeshProUGUI memberName;
        [SerializeField] private TextMeshProUGUI memberHP;
        [SerializeField] private TextMeshProUGUI memberMP;
        [SerializeField] private TextMeshProUGUI memberBaseSTR;
        [SerializeField] private TextMeshProUGUI memberBaseARM;
        [SerializeField] private TextMeshProUGUI memberBaseSPD;
        [SerializeField] private TextMeshProUGUI memberEquipSTR;
        [SerializeField] private TextMeshProUGUI memberEquipARM;
        [SerializeField] private TextMeshProUGUI memberEquipSPD;

        public PartyMember PartyMember => partyMember;

        void OnEnable()
        {
            int siblingIndex = this.gameObject.transform.GetSiblingIndex();
            if (siblingIndex < Party.ActiveMembers.Count)
            {
                partyMember = Party.ActiveMembers[siblingIndex];
                stats = partyMember.Stats as PartyMemberStats;
                DisplayInformation();
            }
        }

        private void DisplayInformation()
        {
            memberName.text = partyMember.Name;
            memberPortrait.sprite = partyMember.MenuPortrait;

            memberHP.text = $"HP: {stats.HP}/{stats.MaxHP}";
            memberMP.text = $"MP: {stats.MP}/{stats.MaxMP}";

            memberBaseSTR.text = $"STR: {stats.BaseSTR}";
            memberBaseARM.text = $"ARM: {stats.BaseARM}";
            memberBaseSPD.text = $"SPD: {stats.BaseSPD}";

            memberEquipSTR.text = $"STR: {stats.STR}";
            ApplySTRColoring();

            memberEquipARM.text = $"ARM: {stats.ARM}";
            ApplyARMColoring();

            memberEquipSPD.text = $"SPD: {stats.SPD}";
            ApplySPDColoring();
        }

        private void ApplySTRColoring()
        {
            if (stats.STR > stats.BaseSTR)
                memberEquipSTR.color = Color.green;
            else if (stats.STR == stats.BaseSTR)
                memberEquipSTR.color = Color.white;
            else
                memberEquipSTR.color = Color.red;
        }
        private void ApplyARMColoring()
        {
            if (stats.ARM > stats.BaseARM)
                memberEquipARM.color = Color.green;
            else if (stats.ARM == stats.BaseARM)
                memberEquipARM.color = Color.white;
            else
                memberEquipARM.color = Color.red;
        }
        private void ApplySPDColoring()
        {
            if (stats.SPD > stats.BaseSPD)
                memberEquipSPD.color = Color.green;
            else if (stats.SPD == stats.BaseSPD)
                memberEquipSPD.color = Color.white;
            else
                memberEquipSPD.color = Color.red;
        }
    }
}

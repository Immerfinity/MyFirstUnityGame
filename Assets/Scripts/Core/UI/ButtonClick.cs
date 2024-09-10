using Battle;
using Core;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class ButtonClick : MonoBehaviour
    {

        public int partyCounter = 1;

        private PartyMember Burdukov;
        private PartyMember Harald;
        private PartyMember Alwyn;
        private PartyMember Levy;

        public GameObject completionWindow;

        private void Awake()
        {
            Burdukov = ScriptableObject.Instantiate(Resources.Load<PartyMember>(Paths.Burdukov));
            Harald = ScriptableObject.Instantiate(Resources.Load<PartyMember>(Paths.Harald));
            Alwyn = ScriptableObject.Instantiate(Resources.Load<PartyMember>(Paths.Alwyn));
            Levy = ScriptableObject.Instantiate(Resources.Load<PartyMember>(Paths.Levy));

        }      

        public void AddBurdukov()
        {
            if (InfoController.Money > 100 && partyCounter <= ActivateObjects.tableCounter)
            {

                Party.AddActiveMember(Burdukov);
                InfoController.Money -= 100;
                partyCounter++;
            }
            else
            {
                ShowCompletionWindow();
            }
        }

        public void AddAlwyn()
        {
            if (InfoController.Money > 20 && partyCounter <= ActivateObjects.tableCounter)
            {


                Party.AddActiveMember(Alwyn);
                InfoController.Money -= 20;
                partyCounter++;
            }
            else
            {
                ShowCompletionWindow();
            }
        }

        public void AddHarald()
        {
            if (partyCounter <= ActivateObjects.tableCounter)
            {
                Party.AddActiveMember(Harald);
                partyCounter++;
            }
            else
            {
                ShowCompletionWindow();
            }
        }

        public void AddLevy()
        {
            if (InfoController.Money > 25 && partyCounter <= ActivateObjects.tableCounter)
            {
                Party.AddActiveMember(Levy);

                InfoController.Money -= 25;
                partyCounter++;
            }
            else
            {
                ShowCompletionWindow();
            }
        }

        public void InitializePartyMember()
        {
            foreach (PartyMember member in Party.ActiveMembers)
            {
                member.Initialize(member);
            }
        }

        private void ShowCompletionWindow()
        {
            completionWindow.SetActive(true);
            StartCoroutine(HideCompletionWindowAfterDelay(3.0f));
        }

        private IEnumerator HideCompletionWindowAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            completionWindow.SetActive(false);
        }

        public void InitializeInventory()
        {
            Burdukov.EquipItem((Equipment)Party.Inventory.Items.Keys.Where(i => i is Weapon).First());
            Burdukov.EquipItem((Equipment)Party.Inventory.Items.Keys.Where(i => i is Armor).First());
            Burdukov.EquipItem((Equipment)Party.Inventory.Items.Keys.Where(i => i is Accessory).First());

            Harald.EquipItem((Equipment)Party.Inventory.Items.Keys.Where(i => i is Weapon).First());
            Harald.EquipItem((Equipment)Party.Inventory.Items.Keys.Where(i => i is Armor).First());
            Harald.EquipItem((Equipment)Party.Inventory.Items.Keys.Where(i => i is Accessory).First());

            Alwyn.EquipItem((Equipment)Party.Inventory.Items.Keys.Where(i => i is Weapon).First());
            Alwyn.EquipItem((Equipment)Party.Inventory.Items.Keys.Where(i => i is Armor).First());
            Alwyn.EquipItem((Equipment)Party.Inventory.Items.Keys.Where(i => i is Accessory).First());

            Levy.EquipItem((Equipment)Party.Inventory.Items.Keys.Where(i => i is Weapon).First());
            Levy.EquipItem((Equipment)Party.Inventory.Items.Keys.Where(i => i is Armor).First());
            Levy.EquipItem((Equipment)Party.Inventory.Items.Keys.Where(i => i is Accessory).First());
        }
    }
}
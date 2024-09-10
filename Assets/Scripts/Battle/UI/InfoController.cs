using Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

namespace Battle
{
    public class InfoController : MonoBehaviour
    {
        private static int money = 1000;

        public static int Money
        {
            get { return money; }
            set
            {
                money += value;
                instance.UpdateMoneyText();
            }
        }

        private static InfoController instance;

        [SerializeField] private TextMeshProUGUI moneyText;

        private void Awake()
        {
            instance = this;
        }

        private void OnEnable()
        {
            UpdateMoneyText();
        }

        private void UpdateMoneyText()
        {
            moneyText.text = $"{Money} Gold";
        }
    }
}
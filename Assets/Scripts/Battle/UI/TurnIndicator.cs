using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class TurnIndicator : MonoBehaviour
    {
        private TurnBar turnBar;
        private RectTransform rectTransform;
        private BattleControl battleControl;

        private void Awake()
        {
            turnBar = GetComponentInParent<TurnBar>();
            rectTransform = GetComponent<RectTransform>();
            battleControl = FindObjectOfType<BattleControl>();
        }

        void Update()
        {
            int targetSlot = (battleControl.TurnNumber < 0) ? 0 : battleControl.TurnNumber;

            Vector2 currentPosition = rectTransform.anchoredPosition;
            Vector2 targetPosition = turnBar.Slots[targetSlot].anchoredPosition;

            float speed = 20f;
            if (battleControl.TurnNumber == 0)
                speed = 30f;

            rectTransform.anchoredPosition = Vector2.MoveTowards(currentPosition, targetPosition + new Vector2(0, 132), speed);
        }
    }
}
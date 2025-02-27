using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class BattlePortrait : MonoBehaviour
    {
        private BattleControl battleControl;
        private RectTransform rectTransform;
        private TurnBar turnBar;
        private Actor actor;

        public void Awake()
        {
            battleControl = FindObjectOfType<BattleControl>();
            rectTransform = GetComponent<RectTransform>();
            turnBar = FindObjectOfType<TurnBar>();

            foreach (RectTransform slot in turnBar.Slots)
            {
                if (slot.GetComponentInChildren<BattlePortrait>() == null)
                {
                    rectTransform.SetParent(slot, false);
                    int index = slot.GetSiblingIndex() - 1;
                    actor = battleControl.TurnOrder[index];
                    SubscribeToActorEvents(actor);
                    break;
                }
            }
        }

        private void Start()
        {
            rectTransform.SetParent(turnBar.transform, false);
        }

        private void Update()
        {
            if (gameObject.activeSelf)
            {
                rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, turnBar.Slots[actor.TurnNumber].anchoredPosition, 200f);
            }
        }
        private void SubscribeToActorEvents(Actor actor)
        {
            actor.WasDefeated += OnDeath;
            actor.Escaped += OnEscape;
        }

        private void UnsubscribeToActorEvents(Actor actor)
        {
            actor.WasDefeated -= OnDeath;
            actor.Escaped -= OnEscape;
        }

        private void OnDeath(Actor actor)
        {
            if (actor is Enemy enemy)
            {
                UnsubscribeToActorEvents(enemy);
                RemovePortrait(enemy);
            }
            else if (actor is Ally ally)
            {
                UnsubscribeToActorEvents(ally);
                RemovePortrait(ally);
            }
        }

        private void OnEscape(Actor actor)
        {
            UnsubscribeToActorEvents(actor);
            RemovePortrait(actor);
        }

        private void RemovePortrait(Actor actor)
        {
            RectTransform slot = turnBar.Slots[actor.TurnNumber];
            turnBar.Slots.Remove(slot);
            Destroy(this.gameObject);
            Destroy(slot.gameObject);
        }
    }
}

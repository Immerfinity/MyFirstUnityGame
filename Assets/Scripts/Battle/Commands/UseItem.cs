using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class UseItem : IBattleCommand
    {
        private Ally allyUsingitem;
        private UsableItem item;

        public bool IsFinished { get; private set; } = false;
        public UseItem(Ally allyUsingitem, UsableItem item)
        {
            this.allyUsingitem = allyUsingitem;
            this.item = item;
        }

        public IEnumerator Co_Execute()
        {
            
            Party.Inventory.RemoveItem(item);

            yield return null;
            IsFinished = true;
        }
    }
}
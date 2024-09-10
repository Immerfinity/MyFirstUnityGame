using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class BarMenuManager
    {
        private StateManager stateManager;
        private BarMenu barMenu;
        public BarMenuManager(StateManager stateManager)
        {
            this.stateManager = stateManager;
            this.barMenu = GameObject.FindObjectOfType<BarMenu>();
        }

        public void OpenMenu()
        {
            if (stateManager.TryState(GameState.BarMenu))
            {
                barMenu.Open();
                barMenu.StartCoroutine(Co_WaitForMenu());
            }
        }
        public IEnumerator Co_WaitForMenu()
        {
            while (barMenu.isOpen)
                yield return null;
            stateManager.RestorePreviousState();
        }
    }
}
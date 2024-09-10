using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Core
{
    public class MenuManager
    {
        private StateManager stateManager;
        private MainMenu menu;
        public MenuManager(StateManager stateManager)
        {
            this.stateManager = stateManager;
            this.menu = GameObject.FindObjectOfType<MainMenu>();
        }

        public void OpenMenu()
        {
            if (stateManager.TryState(GameState.Menu))
            {
                menu.Open();
                menu.StartCoroutine(Co_WaitForMenu());
            }
        }
        public IEnumerator Co_WaitForMenu()
        {
            while(menu.isOpen)
                yield return null;

            stateManager.RestorePreviousState();
        }
    }
}

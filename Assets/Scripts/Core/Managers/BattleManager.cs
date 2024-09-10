using Battle;
using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class BattleManager
    {
        private StateManager stateManager;
        private GameObject battleTransition;
        public BattleManager(StateManager stateManager)
        {
            this.stateManager = stateManager;
            this.battleTransition = Resources.Load<GameObject>("Transitions/BattleTransition");
        }

        public void StartBattle(EnemyPack pack)
        {
            if (stateManager.TryState(GameState.Battle))
                Game.Player.StartCoroutine(Co_StartBattle(pack));
        }
        private IEnumerator Co_StartBattle(EnemyPack pack)
        {
            BattleControl.EnemyPack = pack;

            Animator animator = PlayBattleTransition();
            while (animator.IsAnimating())
                yield return null;

            SceneLoader.LoadBattleScene();
        }

        public void EndBattle()
        {
            SceneLoader.ReloadSavedSceneAfterBattle();
            stateManager.RestorePreviousState();
        }
        public void BossEndBattle()
        {
            SaveManager.ClearData();
            SceneLoader.ReloadSceneAfterBossBattle();
        }


        private Animator PlayBattleTransition()
        {
            Animator animator = GameObject.Instantiate(battleTransition, Game.Player.transform.position, Quaternion.identity).GetComponent<Animator>();
            return animator;
        }
    }
}

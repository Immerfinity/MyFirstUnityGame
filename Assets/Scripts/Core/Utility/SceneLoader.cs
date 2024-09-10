using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public static class SceneLoader
    {
        private static int battleSceneBuildIndex = 3;
        private static int savedSceneBuildIndex;
        private static Vector2 savedPlayerLocation;

        public static void LoadBattleScene()
        {
            GameObject.DontDestroyOnLoad(Game.World.Map);
            Game.World.Map.gameObject.SetActive(false);
            savedSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
            savedPlayerLocation = Game.Player.CurrentCell.Center2D();
            SceneManager.LoadScene(battleSceneBuildIndex);
            SceneManager.sceneLoaded += DisablePlayerObject;
        }

        public static void ReloadSavedSceneAfterBattle()
        {
            SceneManager.sceneLoaded += RestoreMapAndPlayer;
            if (savedSceneBuildIndex == 1)
                savedSceneBuildIndex++;
            SceneManager.LoadScene(savedSceneBuildIndex);
        }

        public static void RestoreMapAndPlayer(Scene scene, LoadSceneMode mode)
        {
            Game.World.Map.gameObject.SetActive(true);
            Game.Player.transform.position = savedPlayerLocation;
            Game.Player.gameObject.SetActive(true);
            SceneManager.sceneLoaded -= RestoreMapAndPlayer;
        }

        private static void DisablePlayerObject(Scene scene, LoadSceneMode mode)
        {
            Game.Player.gameObject.SetActive(false);
        }

        public static void ReloadSceneAfterBossBattle()
        {
            SceneManager.sceneLoaded += DestroyMapAndPlayer;
            SceneManager.LoadScene(0);           
        }

        public static void DestroyMapAndPlayer(Scene scene, LoadSceneMode mode)
        {
            savedPlayerLocation = Game.Player.CurrentCell.Center2D();
            Game.World.Map.gameObject.SetActive(true);
            Game.Player.transform.position = savedPlayerLocation;
            Game.Player.gameObject.SetActive(true);
            SceneManager.sceneLoaded -= RestoreMapAndPlayer;
        }
    }
}

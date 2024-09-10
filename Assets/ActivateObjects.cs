using Battle;
using Codice.Client.BaseCommands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ActivateObjects : MonoBehaviour
    {
        public GameObject completionWindow;

        public GameObject tablePrefab;
        public GameObject chaerPrefab;

        public List<Vector3> tableSpawnPositions;
        public List<Vector3> chaerSpawnPositions;
        private int tableCurrentIndex = 0;
        private int chaerCurrentIndex = 0;

        public static int tableCounter = 1;
        public static int chaerCounter = 1;


        public void SpawnChair()
        {
            if ((chaerCounter <= 4) && (InfoController.Money > 25))
            {
                Vector3 nextSpawnPosition = chaerSpawnPositions[chaerCurrentIndex];

                Instantiate(chaerPrefab, nextSpawnPosition, Quaternion.identity);

                chaerCurrentIndex = (chaerCurrentIndex + 1) % chaerSpawnPositions.Count;

                InfoController.Money -= 25;
                chaerCounter++;
            }
            else
            {
                ShowCompletionWindow();
            }

        }

        public void SpawnTable()
        {

            if ((tableCounter <= 4) && (InfoController.Money > 5))
            {
                Vector3 nextSpawnPosition = tableSpawnPositions[tableCurrentIndex];

                Instantiate(tablePrefab, nextSpawnPosition, Quaternion.identity);

                tableCurrentIndex = (tableCurrentIndex + 1) % tableSpawnPositions.Count;

                InfoController.Money -= 5;
                tableCounter++;
            }
            else
            {
                ShowCompletionWindow();
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
    }
}

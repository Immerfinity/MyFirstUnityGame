using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBossPanel : MonoBehaviour
{

    public GameObject completionWindow;

    private void Start()
    {
        if (BattleRegion.currentIndex == 4)
        {
            ShowCompletionWindow();
        }
    }

    private void ShowCompletionWindow()
    {
        completionWindow.SetActive(true);
        StartCoroutine(HideCompletionWindowAfterDelay(2.0f));
    }

    private IEnumerator HideCompletionWindowAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        completionWindow.SetActive(false);
    }
}

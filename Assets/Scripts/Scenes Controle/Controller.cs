using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public void Drop(int value)
    {
        if (value == 0)
        {
            Screen.SetResolution(1920, 1080, true);
            Debug.LogWarningFormat("Size:1920x1080 !!!");
        }
        if (value == 1)
        {
            Screen.SetResolution(1366, 768, true);
            Debug.LogWarningFormat("Size:1366x768 !!!");
        }
        if (value == 2)
        {
            Screen.SetResolution(16, 9, true);
            Debug.LogWarningFormat("Size:16x9 !!!");
        }

    }

}

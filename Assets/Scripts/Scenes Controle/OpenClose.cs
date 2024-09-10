using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour
{
    public GameObject plane;
    bool active;

    public void OpenAndClose()
    {
        if (active == false)
        {
            plane.transform.gameObject.SetActive(true);
            active = true;
        }
        else
        {
            plane.transform.gameObject.SetActive(false);
            active = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeinMenu : MonoBehaviour
{
   public void Scenes(int numberScenes)
   {
        SaveManager.LoadGameData();
        SceneManager.LoadScene(1);
   }
    public void Exitgame() 
    {  
        Application.Quit();
        Debug.Log("Exit!!!");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Level01");
    }  
    public void LoadSecondLevel()
    {
        SceneManager.LoadScene("Level02");
    }
}

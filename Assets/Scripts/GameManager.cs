using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // I want to use singleton here for convinience.
    // Makes it easier to call from other objects. 
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // I want to use singleton here for convinience.
    // Makes it easier to call from other objects. 
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }
}

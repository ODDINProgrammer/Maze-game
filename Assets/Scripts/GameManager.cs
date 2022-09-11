using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // I want to use singleton here for convinience.
    // Makes it easier to call from other objects. 
    public static GameManager Instance;
    [SerializeField] internal Transform _player;
    public GameState CurrentGameState;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _player = FindObjectOfType<PlayerControl>().transform;
    }
    public void ChangeGameState(GameState newState)
    {
        switch(newState)
        {
            case GameState.PlayerTurn:
                break;
            case GameState.MinotaurTurn:
                break;
            default:
                break;
        }
    }
    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public enum GameState
    {
        PlayerTurn = 0,
        MinotaurTurn = 1,
    }
}

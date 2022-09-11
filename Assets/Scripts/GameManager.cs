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
    [SerializeField] internal Transform _minotaur;
    public GameState CurrentGameState;


    [Header("Accessors")]
    [SerializeField] private ActorPositionsOnThisTurn _actorPosition;
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
        CurrentGameState = newState;
        switch (newState)
        {
            case GameState.PlayerTurn:
                Debug.Log("Player turn started!");
                break;
            case GameState.MinotaurTurn:
                Debug.Log("Minotaur turn started!");
                if (_minotaur == null)
                {
                    ChangeGameState(GameState.NewRound);
                }
                break;
            case GameState.NewRound:
                Debug.Log("New round started!");
                _actorPosition.StorePositions();
                break;
            case GameState.Win:
                Debug.Log("Level cleared!");
                break;
            default:
                break;
        }
    }
    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SkipTurn()
    {
        ChangeGameState(GameState.MinotaurTurn);
    }
    public enum GameState
    {
        PlayerTurn = 0,
        MinotaurTurn = 1,
        NewRound = 2,
        Win = 3
    }
}

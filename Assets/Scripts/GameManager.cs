using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //  I want to use singleton here for convinience.
    //  Makes it easier to call from other objects. 
    #region GameManager singleton
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [Header("Player")]
    [SerializeField] internal Transform _player;
    [Header("Minotaur")]
    [SerializeField] internal Transform _minotaur;
    [SerializeField] private int _minotaurTurnCount = 2;    // Defines how many moves minotaur makes during its turn
    [SerializeField] private int _minotaurCurrentTurnCount; // Used for minotaur movement logic 
    [Header("Current state")]
    public GameState CurrentGameState;

    [Header("Accessors")]
    [SerializeField] private ActorPositionsOnThisTurn _actorPosition;

    private void Start()
    {
        _minotaurCurrentTurnCount = _minotaurTurnCount;
    }
    public void ChangeGameState(GameState newState)
    {
        CurrentGameState = newState;
        switch (newState)
        {
            #region Player turn
            case GameState.PlayerTurn:
                Debug.Log("Player turn started!");
                break;
            #endregion

            #region Minotaur turn
            case GameState.MinotaurTurn:
                Debug.Log("Minotaur turn started!");
                //  For levels without minotaur skip its turn
                if (_minotaur == null)
                {
                    ChangeGameState(GameState.NewRound);
                    break;
                }
                //  Make as many moves as defined
                _minotaurCurrentTurnCount--;
                if (_minotaurCurrentTurnCount >= 0)
                {
                    BaseMinotaurLogic.Instance.MovementLogic();
                    break;
                }

                ChangeGameState(GameState.NewRound);
                break;
            #endregion

            #region New round
            case GameState.NewRound:
                Debug.Log("New round started!");
                _actorPosition.StorePositions();
                _minotaurCurrentTurnCount = _minotaurTurnCount;
                ChangeGameState(GameState.PlayerTurn);
                break;
            #endregion

            #region Win
            case GameState.Win:
                Debug.Log("Level cleared!");
                break;
            #endregion

            #region Lose
            case GameState.Lose:
                Debug.Log("You lost!!!");
                break;
            #endregion
            default:
                break;
        }
    }

    #region Button event methods
    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SkipTurn()
    {
        ChangeGameState(GameState.MinotaurTurn);
    }
    public void QuitGame()
    {
        Debug.Log("Quiting");
        Application.Quit();
    }

    public void GoToMenu()
    {
        Debug.Log("Entering menu");
        SceneManager.LoadScene("Menu");
    }

    #endregion
    public enum GameState
    {
        PlayerTurn = 0,
        MinotaurTurn = 1,
        NewRound = 2,
        Win = 3,
        Lose = 4
    }
}

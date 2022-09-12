using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMinotaurLogic : MonoBehaviour
{
    #region Minotaur singleton
    public static BaseMinotaurLogic Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField] internal Transform _player;            //  Will be used to access player position for intelligent minotaur???
    [SerializeField] protected Vector2 _destination;        //  Used to move minotaur to desired position
    [SerializeField] protected Vector2 _testedDestination;  //  Used to check if minotaur can walk to this position
    [SerializeField] protected int _moveSpeed = 5;          //  Used to define movement speed. Increase it for faster game flow

    [SerializeField] protected bool _catchedPlayer = false;
    private void Start()
    {
        //  Set destination to current position to ensure that it stays in place
        _destination = transform.position;
        //  Store itself to game manager
        GameManager.Instance._minotaur = transform;

        _player = GameManager.Instance._player;
    }

    public virtual void MovementLogic() { }
    protected virtual void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.MinotaurTurn)
        {
            //  If new destination was found, move there
            if (Vector3.Distance(transform.position, _destination) > 0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, _destination, _moveSpeed * Time.deltaTime);
            }

            //  If destination reached make another move
            //  Will only take turn if any left, check GameManager -> GameState section
            if (Vector3.Distance(transform.position, _destination) == 0f)
            {
                if (_catchedPlayer)
                {
                    GameManager.Instance.ChangeGameState(GameManager.GameState.Lose);
                    return;
                }

                GameManager.Instance.ChangeGameState(GameManager.GameState.MinotaurTurn);
            }
        }
    }

    //  This method contains logic for checking if minotaur can move towards picked position
    //  If it can't or it tries to step on something where there are no tile, it will find another tile 
    protected void CheckIfMoveIsPossible(Vector2 nextMovePos)
    {
        //If tile doesnt exist pick another one.
        if (FindObjectOfType<GenerateMaze>().GetTileAtPosition(_testedDestination) == null)
        {
            MovementLogic();
        }

        //Else if tile exists
        var tile = FindObjectOfType<GenerateMaze>().GetTileAtPosition(_testedDestination);
        //Check if tile is walkable 
        if (tile.Walkable)
        {
            _destination = nextMovePos;
            return;
        }
        else if (!tile.Walkable) //Else find another one
        {
            MovementLogic();
        }
    }

    //  Check for collision with player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _player.gameObject)
        {
            _catchedPlayer = true;
        }

    }
}

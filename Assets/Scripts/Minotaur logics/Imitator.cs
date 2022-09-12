using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imitator : BaseMinotaurLogic
{
    #region Imitator singleton
    public static Imitator Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField] internal Vector2 _playerMove;
    public MovementDir Direction;

    public override void MovementLogic()
    {
        ConvertPlayerMove();
        switch (Direction)
        {
            case MovementDir.UP:
                Debug.Log("Going up");
                break;
            case MovementDir.Down:
                Debug.Log("Going down");
                break;
            case MovementDir.Left:
                Debug.Log("Going left");
                break;
            case MovementDir.Right:
                Debug.Log("Going right");
                break;
            default:
                break;
        }
    }

    private void ConvertPlayerMove()
    {
        Vector2 playerMove = PlayerControl.Instance._lastMove;
        Debug.Log($"Last player move {playerMove}");
        if (playerMove == Vector2.up)
        {
            Direction = MovementDir.UP;
        }
        if (playerMove == Vector2.down)
        {
            Direction = MovementDir.Down;
        }
        if (playerMove == Vector2.left)
        {
            Direction = MovementDir.Left ;
        }
        if (playerMove == Vector2.right)
        {
            Direction = MovementDir.Right;
        }

        MovementLogic();
    }

    public enum MovementDir
    {
        UP,
        Down,
        Left,
        Right
    }
}

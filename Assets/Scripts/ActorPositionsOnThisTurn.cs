using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorPositionsOnThisTurn : MonoBehaviour
{
    [SerializeField] private Vector2 _previousPlayerPos;
    [SerializeField] private Vector2 _previousMinotaurPos;
    public void StorePositions()
    {
        if (GameManager.Instance._player != null)
            _previousPlayerPos = GameManager.Instance._player.position;
        if (GameManager.Instance._minotaur != null)
            _previousMinotaurPos = GameManager.Instance._minotaur.position;
    }

    public void UndoMove()
    {
        GameManager.Instance.CurrentGameState = GameManager.GameState.PlayerTurn;
        PlayerControl.Instance.transform.position = _previousPlayerPos;
        PlayerControl.Instance.Destination = _previousPlayerPos;
    }
}

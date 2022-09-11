using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorPositionsOnThisTurn : MonoBehaviour
{
    [SerializeField] private Vector2 _previousPlayerPos;
    public void StorePositions()
    {
        _previousPlayerPos = GameManager.Instance._player.position;
    }

    public void UndoMove()
    {
        GameManager.Instance.CurrentGameState = GameManager.GameState.PlayerTurn;
        PlayerControl.Instance.transform.position = _previousPlayerPos;
        PlayerControl.Instance.Destination = _previousPlayerPos;
    }
}

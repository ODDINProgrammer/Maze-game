using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorPositionsOnThisTurn : MonoBehaviour
{
    [SerializeField] private Vector2 _playerPos;
    public void StorePositions()
    {
        _playerPos = GameManager.Instance._player.position;
    }
}

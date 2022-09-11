using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private bool _walkable;
    [SerializeField] private bool _finish;
    public bool Walkable { get => _walkable; }

    private void OnMouseDown()
    {
        if (GameManager.Instance.CurrentGameState != GameManager.GameState.PlayerTurn) return;
        var player = FindObjectOfType<PlayerControl>();
        if (Vector3.Distance(transform.position, player.transform.position) <= 1f && _walkable)
        {
            player.Destination = transform.position;
        }
        GameManager.Instance.ChangeGameState(GameManager.GameState.MinotaurTurn);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private bool _walkable;
    public bool Walkable { get => _walkable; }

    //  Player movement logic 
    private void OnMouseDown()
    {
        //  If its not player's turn skip logic
        if (GameManager.Instance.CurrentGameState != GameManager.GameState.PlayerTurn) return;
        //  Else find player
        var player = PlayerControl.Instance;
        //  Set its destination if:
        //      *hasn't clicked on unwalkable tile
        //      *hasn't clicked on tile which is more than 1 tile away
        //      *hasn't clicked on diagonal tile
        //  Then let minotaur take turn
        if (Vector3.Distance(transform.position, player.transform.position) <= 1f && _walkable)
        {
            player.Destination = transform.position;
            Debug.Log(transform.position - player.transform.position);
            player._lastMove = transform.position - player.transform.position;
            GameManager.Instance.ChangeGameState(GameManager.GameState.MinotaurTurn);
        }
    }
}

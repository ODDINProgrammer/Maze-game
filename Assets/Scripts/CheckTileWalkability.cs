using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTileWalkability : MonoBehaviour
{
    [SerializeField] private bool _tileIsWalkable = false;
    [SerializeField] private Transform _player;

    public void CanMove()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Tile>() == null) return;

        var tile = collision.gameObject.GetComponent<Tile>();
        if (tile != _player.GetComponent<PlayerControl>()._currentTile)
        {
            if (tile.Walkable)
            {
                _player.GetComponent<PlayerControl>().Destination = tile.transform.position;
                return;
            }
            else if (!tile.Walkable)
            {
                transform.position = _player.position;
                return;
            }
        }
    }
}

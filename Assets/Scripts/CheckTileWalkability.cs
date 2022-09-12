using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTileWalkability : MonoBehaviour
{
    [SerializeField] private bool _walkable = false;
    [SerializeField] private Transform _player;

    //public bool CanMove()
    //{
    //    if (GetComponent<Tile>() == null) return false;
    //    return _walkable;
    //}
    //private bool OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.GetComponent<Tile>() == null) return false;

    //    var tile = collision.gameObject.GetComponent<Tile>();
    //    if (tile.Walkable)
    //    {
    //        return true;
    //    }
    //    else if (!tile.Walkable)
    //    {
    //        return false;
    //    }

    //    return false;
    //}
}

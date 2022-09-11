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
        var player = FindObjectOfType<PlayerControl>();
        if (Vector3.Distance(transform.position, player.transform.position) <= 1f && _walkable)
        {
            player.Destination = transform.position;
        }
    }
}

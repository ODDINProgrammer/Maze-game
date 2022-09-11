using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance;

    [SerializeField] private GameObject _maze;
    [SerializeField] private Transform _playerMoveCheck;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Vector2 _destination;
    public Vector2 Destination { set { _destination = value; } }

    public Tile _currentTile;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _destination = transform.position;
    }
    private void Update()
    {
        //If tile is walkable, move player
        if (Vector3.Distance(transform.position, _destination) > 0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _destination, _moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Tile>() == null) return;

        var tile = collision.gameObject.GetComponent<Tile>();

        if (tile.Walkable)
        {
            return;
        }
        else if (!tile.Walkable)
        {
            transform.position = transform.position;
            return;
        }
    }
}


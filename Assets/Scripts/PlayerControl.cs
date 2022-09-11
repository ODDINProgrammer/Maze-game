using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject _maze;
    [SerializeField] private Transform _playerMoveCheck;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Vector2 _destination;
    public Vector2 Destination { set { _destination = value; } }

    public Tile _currentTile;

    private void Start()
    {
        _destination = transform.position;
    }
    private void Update()
    {
        //if (Vector3.Distance(transform.position, _playerMoveCheck.position) == 0f)
        //{
        ReadUserInput();
        //}
        //If tile is walkable, move player
        if (Vector3.Distance(transform.position, _destination) > 0f)
        {
            //transform.position = Vector3.MoveTowards(transform.position, _playerMoveCheck.position, _moveSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, _destination, _moveSpeed * Time.deltaTime);
        }
        ////If tile is not walkable, return moveChecker back to player position
        //else if (!_playerMoveCheck.GetComponent<CheckTileWalkability>().CanMove())
        //{
        //    _playerMoveCheck.position = transform.position;
        //}

    }

    
    private void ReadUserInput()
    {
        
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    _destination += new Vector2(0f, 1f);
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    _destination += new Vector2(0f, -1f);
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    _destination += new Vector2(1f, 0f);
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    _destination += new Vector2(-1f, 0f);
        //}
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


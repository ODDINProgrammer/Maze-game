using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    #region Player Singleton
    public static PlayerControl Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField] private float _moveSpeed = 5f;              // Player speed 
    [SerializeField] private Vector2 _destination;               // Position to which player will move
    [SerializeField] internal Vector2 _lastMove;
    public Vector2 Destination { set { _destination = value; } } // Destination property to provide access to other objects

   
    private void Start()
    {
        //  Set destination to current position to ensure that it stays in place
        _destination = transform.position;
        //  Store player transform in game manager
        GameManager.Instance._player = transform;
    }
    private void Update()
    {
        //If tile which player has pressed is close enough and is walkable, walk there
        if (Vector3.Distance(transform.position, _destination) > 0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _destination, _moveSpeed * Time.deltaTime);
        }
    }
}


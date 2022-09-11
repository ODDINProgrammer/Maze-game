using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMinotaurLogic : MonoBehaviour
{
    [SerializeField] protected Transform _player;
    [SerializeField] protected Vector2 _destination;
    [SerializeField] protected Vector2 _testedDestination;
    [SerializeField] protected int _moveSpeed = 5;

    [SerializeField] protected GameObject _tileChecker;

    private void Start()
    {
        _destination = transform.position;
    }

    public virtual void MovementLogic() { }
    private void Update()
    {
        if (Vector3.Distance(transform.position, _destination) > 0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _destination, _moveSpeed * Time.deltaTime);
        }
    }

    protected void CheckIfMoveIsPossible(Vector2 nextMovePos)
    {
        //If tile doesnt exist or is not walkable pick another one.
        if (FindObjectOfType<GenerateMaze>().GetTileAtPosition(_testedDestination) == null)
        {
            MovementLogic();
        }
        // _tileChecker.gameObject.SetActive(true);
        //_tileChecker.transform.position = nextMovePos;

        //if (_tileChecker.GetComponent<CheckTileWalkability>().CanMove() == false)
        //{
        //    MovementLogic();
        //    return;
        //}

        //Else if tile exists
        var tile = FindObjectOfType<GenerateMaze>().GetTileAtPosition(_testedDestination);
        //Check if tile is walkable 
        if (tile.Walkable)
            _destination = nextMovePos;
        else if(!tile.Walkable) //Else find another one
        {
            MovementLogic();
        }
        // _tileChecker.gameObject.SetActive(false);
    }
}

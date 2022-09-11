using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMinotaurLogic : MonoBehaviour
{
    [SerializeField] protected Transform _player;
    [SerializeField] protected Vector2 _destination;
    [SerializeField] protected int _moveSpeed = 5;

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
}

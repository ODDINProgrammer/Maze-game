using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerateMaze : MonoBehaviour
{
    [SerializeField] private int _mapSize;
    [SerializeField] private Tile _tilePrefab;

    private void Start()
    {
        GenerateNewMaze();
    }

    public void GenerateNewMaze()
    {
        if(transform.childCount > 0)
        {
            foreach(Transform child in transform)
            {
                DestroyImmediate(child.gameObject);
            }
        }

        for (int x = 0; x <= _mapSize; x++)
        {
            for (int y = 0; y <= _mapSize; y++)
            {
                var newTile = Instantiate(_tilePrefab, new Vector2(x, y), Quaternion.identity, transform);
                newTile.name = $"Tile {x} {y}";
            }
        }
    }
}

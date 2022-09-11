using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerateMaze : MonoBehaviour
{
    [SerializeField] private Vector2 _mapSize;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Texture2D _map;
    [SerializeField] private ColorToPrefab[] _colorMappings;

    private Dictionary<Vector2, Tile> _tiles = new Dictionary<Vector2, Tile>();
    private void Start()
    {
        //GenerateNewMaze();
        NewMazeGeneration();
        StoreAllTiles();
    }

    public void GenerateNewMaze()
    {
        for (int x = 0; x <= _mapSize.x; x++)
        {
            for (int y = 0; y <= _mapSize.y; y++)
            {
                var newTile = Instantiate(_tilePrefab, new Vector2(x, y), Quaternion.identity, transform);
                newTile.name = $"{newTile.name} {x} {y}";
                _tiles[new Vector2(x, y)] = newTile;
            }
        }
    }


    public void DeleteAllTiles()
    {
        if (transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                DestroyImmediate(child.gameObject);
            }
        }
    }
    private void NewMazeGeneration()
    {
        for (int x = 0; x <= _mapSize.x; x++)
        {
            for (int y = 0; y <= _mapSize.y; y++)
            {
                var newTile = Instantiate(_tilePrefab, new Vector2(x, y), Quaternion.identity, transform);
                newTile.name = $"{newTile.name} {x} {y}";
                _tiles[new Vector2(x, y)] = newTile;
            }
        }
    }
    private void GenerateTile(int x, int y)
    {
        Color pixelColor = _map.GetPixel(x, y);
        if(pixelColor.a == 0f)
        {
            //Nothing to render 
            return;
        }

        foreach(ColorToPrefab colorMapping in _colorMappings)
        {
            Vector2 pos = new Vector2(x, y);
            var newTile = Instantiate(colorMapping._prefab, pos, Quaternion.identity, transform);
            newTile.name = $"{newTile.name} {x} {y}";
            _tiles[new Vector2(x, y)] = newTile.GetComponent<Tile>();
        }


    }
    private void StoreAllTiles()
    {
        foreach (Transform tile in transform)
        {
            _tiles[tile.transform.position] = tile.GetComponent<Tile>();
        }
        Debug.Log($"There are: {_tiles.Count} tiles in a maze");
    }

    //Using for minotaur movement
    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }
        return null;
    }
}

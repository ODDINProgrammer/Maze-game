using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerateMaze : MonoBehaviour
{
    [SerializeField] private Vector2 _mapSize;  //  Controls map size
    [SerializeField] private Tile _tilePrefab;  //  Tile to generate (Generates sand). Used in pair with mapSize to create basis,
                                                //  from where you can design your own maps.

    private Dictionary<Vector2, Tile> _tiles = new Dictionary<Vector2, Tile>(); //  Dictionary which stores tile data. Used in walking logics.
    private void Start()
    {
        StoreAllTiles();
    }

    //  This method is used to create basic maze. It spawns prefab tiles(currently sand) on all tiles defined by mapSize
    //  Used for Create maze button in the inspector window
    public void GenerateNewMaze()
    {
        for (int x = 0; x <= _mapSize.x; x++)
        {
            for (int y = 0; y <= _mapSize.y; y++)
            {
                //  Creating new tile 
                var newTile = Instantiate(_tilePrefab, new Vector2(x, y), Quaternion.identity, transform);
                //  Renaming it
                newTile.name = $"{newTile.name} {x} {y}";
                //  And store it in a dictionary for later access
                _tiles[new Vector2(x, y)] = newTile;
            }
        }
    }

    //  Removes all(not really, dont know why) children objects
    //  Used for Delete button in the inspector window
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

    //  Stores all tiles in the begining of the game 
    //  As I haven't managed to create clever way to design maps, I manually create and position tiles in the inspector 
    //  hence all tiles should be stored 
    private void StoreAllTiles()
    {
        foreach (Transform tile in transform)
        {
            _tiles[tile.transform.position] = tile.GetComponent<Tile>();
        }
        Debug.Log($"There are: {_tiles.Count} tiles in a maze");
    }

    //  Used for minotaur movement
    //  Returns tile date at desired position if tile exists
    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }
        return null;
    }
}

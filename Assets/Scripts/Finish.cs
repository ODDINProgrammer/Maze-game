using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : Tile
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.ChangeGameState(GameManager.GameState.Win);
    }
}

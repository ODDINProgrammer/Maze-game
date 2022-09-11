using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumb : BaseMinotaurLogic
{
    public override void MovementLogic()
    {
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0: // Go left
                _destination += new Vector2(-1f, 0f);
                break;
            case 1: // Go right
                _destination += new Vector2(1f, 0f);
                break;
            case 2: // Go up
                _destination += new Vector2(0f, 1f);
                break;
            case 3: // Go Down
                _destination += new Vector2(0f, -1f);
                break;
            default:
                break;
        }

        //base.MovementLogic();
    }
}

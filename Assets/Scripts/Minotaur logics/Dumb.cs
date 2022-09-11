using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumb : BaseMinotaurLogic
{
    public override void MovementLogic()
    {
        _testedDestination = transform.position;
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0: // Go left
                _testedDestination += new Vector2(-1f, 0f);
                break;
            case 1: // Go right
                _testedDestination += new Vector2(1f, 0f);
                break;
            case 2: // Go up
                _testedDestination += new Vector2(0f, 1f);
                break;
            case 3: // Go Down
                _testedDestination += new Vector2(0f, -1f);
                break;
            default:
                break;
        }
        CheckIfMoveIsPossible(_testedDestination);
        //base.MovementLogic();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : GameEntity {
    public bool right = true;

    public override void Act()
    {
        if (right)
        {
            gameController.MoveWalker(this, new Vector2Int(1, 0));
        }
        else
        {
            gameController.MoveWalker(this, new Vector2Int(-1, 0));
        }

    }

    public void turn()
    {
        right = !right;
        GetComponent<SpriteRenderer>().flipX = !right;
    }
}
